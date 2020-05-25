using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vectorize.Domain.Parser;
using Vectorize.Domain;
using OneOf;

namespace Vectorize.Interpreter
{
    public class State : VectorizeBaseVisitor<IVecValue>
    {
        private readonly Stack<Scope> scopes;
        private readonly Dictionary<string, BuiltInFunction> builtInFunctions;
        private readonly BuiltInFunctionContext builtInFunctionContext;
        private readonly Dictionary<string, VectorizeParser.FunctionContext> functions;
        private readonly List<string> errors;

        public State()
        {
            builtInFunctionContext = new BuiltInFunctionContext(this);
            builtInFunctions = BuiltInFunction.List
                .ToDictionary(f => f.Name, f => f);

            Output = new StringBuilder();

            scopes = new Stack<Scope>();
            functions = new Dictionary<string, VectorizeParser.FunctionContext>();
            errors = new List<string>();
        }

        public StringBuilder Output { get; }

        public string StrokeColor { get; set; }
        public float? StrokeWidth { get; set; }
        public string FillColor { get; set; }
        public int? FontSize { get; set; }

        private Scope CurrentScope => scopes.Peek();

        public Result ToResult()
            => new Result(Output.ToString(), errors);

        public void Run(VectorizeParser.ProgramContext program)
        {
            foreach (var function in program.function())
            {
                var name = function.ID().GetText();
                if (functions.ContainsKey(name))
                    errors.Add($"Function '{name}' already defined! - only first def. is used");
                functions[name] = function;
            }

            if (functions.ContainsKey("main"))
            {
                var mainFunc = functions["main"];
                try
                {
                    Output.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                    Output.AppendLine("<!DOCTYPE svg>");

                    scopes.Push(new Scope("main"));
                    VisitFunction(mainFunc);
                    scopes.Pop();

                    Output.AppendLine("</svg>");
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
            }
            else
            {
                errors.Add("No main function found!");
            }
        }

        private IVecValue Run(string name, IVecValue[] args)
        {
            if (!functions.ContainsKey(name))
                throw new InvalidOperationException($"Function '{name}' is not defined!");

            var function = functions[name];
            var returnType = ParseType(function.type());
            bool returnIsArray = function.array != null;

            var funcArgs = function.funcparam()
                .Select(p => (name: p.ID().GetText(), type: ParseType(p.type()), isArray: p.array != null))
                .ToArray();
            if (funcArgs.Length != args.Length)
                throw new InvalidOperationException("Argument list length must match!");

            if (scopes.Count > 50)
            {
                throw new InvalidOperationException(
                    $"Stack Overflow! " +
                    $"Function: {name} " +
                    $"Args: {string.Join(", ", args.Select(a => a.ToString()))}");
            }

            scopes.Push(new Scope(name));
            for (int i = 0; i < funcArgs.Length; i++)
            {
                var arg = funcArgs[i];
                if (arg.isArray)
                {
                    if (args[i].Type != VecValueType.Array)
                        throw new InvalidOperationException($"Function '{name}': Excepted array at position {i}! Was: {args[i].Type}");
                    var container = (IVecContainer)args[i];
                    if (arg.type != container.ElementType)
                        throw new InvalidOperationException($"Function '{name}': Element type must match at position {i}! Excepted: {arg.type} Was: {container.ElementType}");
                }
                else
                {
                    if (arg.type != args[i].Type)
                        throw new InvalidOperationException($"Function '{name}': Type must match at position {i}! Excepted: {arg.type} Was: {args[i].Type}");
                }
                CurrentScope.DeclareVariable(arg.name, args[i]);
            }

            VisitStatement(function.statement());

            var result = CurrentScope.ReturnValue;
            if (returnIsArray)
            {
                if (result.Type != VecValueType.Array)
                    throw new InvalidOperationException($"Function '{name}': Must return an array! Was: {result.Type}");
                var container = (IVecContainer)result;
                if (container.ElementType != returnType)
                    throw new InvalidOperationException($"Function '{name}': Must return an array of type '{returnType}'! Was: {container.ElementType}");
            }
            else
            {
                if (result.Type != returnType)
                    throw new InvalidOperationException($"Function '{name}': Return type must be '{returnType}'! Was: {result.Type}");
            }
            scopes.Pop();

            return result;
        }

        public override IVecValue VisitStatement([NotNull] VectorizeParser.StatementContext context)
        {
            if (!CurrentScope.IsReturning)
            {
                return base.VisitStatement(context);
            }
            return VecNull.Value;
        }

        public override IVecValue VisitIfstmt([NotNull] VectorizeParser.IfstmtContext context)
        {
            var conds = context.expression();
            var stmts = context.statement();
            bool anyMatch = false;
            foreach (var (condition, statement) in conds.Zip(stmts, (c, s) => (condition: c, statement: s)))
            {
                bool value = ((VecBool)condition.Accept(this)).Value;
                if (value)
                {
                    anyMatch = true;
                    statement.Accept(this);
                    break;
                }
            }
            if (!anyMatch && stmts.Length == conds.Length + 1) // is else present?
            {
                var elseBranch = stmts.Last();
                elseBranch.Accept(this);
            }

            return VecNull.Value;
        }

        public override IVecValue VisitWhilestmt([NotNull] VectorizeParser.WhilestmtContext context)
        {
            scopes.Push(new Scope("while", CurrentScope));

            var condition = context.expression();
            var body = context.statement();

            bool running = ((VecBool)condition.Accept(this)).Value;
            while (running)
            {
                body.Accept(this);

                running = ((VecBool)condition.Accept(this)).Value;
            }

            scopes.Pop();

            return VecNull.Value;
        }

        public override IVecValue VisitForstmt([NotNull] VectorizeParser.ForstmtContext context)
        {
            scopes.Push(new Scope("for", CurrentScope));
            context.vardef().Accept(this);

            var condition = context.expression(0);
            var body = context.statement();
            var post = context.expression(1);

            bool running = ((VecBool)condition.Accept(this)).Value;
            while (running)
            {
                scopes.Push(new Scope("body", CurrentScope));
                body.Accept(this);
                scopes.Pop();

                post.Accept(this);

                running = ((VecBool)condition.Accept(this)).Value;
            }
            scopes.Pop();

            return VecNull.Value;
        }

        public override IVecValue VisitVarassignstmt([NotNull] VectorizeParser.VarassignstmtContext context)
        {
            var name = context.ID().GetText();
            var value = context.value.Accept(this);
            var oldValue = CurrentScope[name];

            if (context.index == null)
            {
                if (oldValue.Type != value.Type)
                    throw new InvalidOperationException($"Variable '{name}' is of type '{oldValue.Type}' and cannot be assigned a '{value.Type}' value!");

                CurrentScope[name] = value;
            }
            else
            {
                if (oldValue is IVecContainer container)
                {
                    var idxV = context.index.Accept(this);
                    if (idxV is VecInt idx)
                    {
                        container.Set(idx.Value, value);
                    }
                    else
                        throw new InvalidOperationException($"Index must be an int! Was: {idxV.Type}");
                }
                else
                    throw new InvalidOperationException($"Variable '{name}' must be an array to use indexing!");
            }

            return VecNull.Value;
        }

        public override IVecValue VisitReturnstmt([NotNull] VectorizeParser.ReturnstmtContext context)
        {
            var returnValue = context.expression().Accept(this);
            CurrentScope.ReturnValue = returnValue;
            CurrentScope.IsReturning = true;

            return VecNull.Value;
        }

        public override IVecValue VisitVardef([NotNull] VectorizeParser.VardefContext context)
        {
            var name = context.ID().GetText();
            var type = ParseType(context.type());
            bool isArray = context.array != null;
            var initialValue = context.initial?.Accept(this);
            var sizeV = context.size?.Accept(this);

            if (initialValue != null)
            {
                if (isArray)
                {
                    if (initialValue.Type != VecValueType.Array)
                        throw new InvalidOperationException($"Variable '{name}': Initial value must be array! Was: {initialValue.Type}");
                    var container = (IVecContainer)initialValue;
                    if (container.ElementType != type)
                        throw new InvalidOperationException($"Variable '{name}': Initial value must be array of type {type}! Was: {container.ElementType}");
                }
                else
                {
                    if (type != initialValue.Type)
                        throw new InvalidOperationException($"Type must match for initial value of variable!");
                }
            }
            else
            {
                if (isArray)
                    if (sizeV == null)
                        initialValue = ConstructDefault(type, 0);
                    else if (sizeV is VecInt size)
                        initialValue = ConstructDefault(type, size.Value);
                    else
                        throw new InvalidOperationException($"Size of array must be a int! Was: {sizeV.Type}");
                else
                    initialValue = ConstructDefault(type);
            }
            CurrentScope.DeclareVariable(name, initialValue);

            return VecNull.Value;
        }

        public override IVecValue VisitArrayAccess([NotNull] VectorizeParser.ArrayAccessContext context)
        {
            var name = context.ID().GetText();
            var value = CurrentScope[name];
            var idxV = context.expression().Accept(this);

            if (value is IVecContainer container)
            {
                if (idxV is VecInt idx)
                    return container.Get(idx.Value);
                else
                    throw new InvalidOperationException($"Index must be a int! Was: {idxV.Type}");
            }
            else
                throw new InvalidOperationException($"Variable '{name}' must be an array to use indexing!");
        }

        public override IVecValue VisitUnary([NotNull] VectorizeParser.UnaryContext context)
        {
            var expr = context.expression();
            if (expr is VectorizeParser.VarContext var)
            {
                var name = var.ID().GetText();
                var oldValue = CurrentScope[name];
                IVecValue newValue;
                switch (context.op.Text)
                {
                    case "++":
                        newValue = oldValue.Add(VecInt.One);
                        break;
                    case "--":
                        newValue = oldValue.Subtract(VecInt.One);
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown operator '{context.op.Text}'!");
                }
                CurrentScope[name] = newValue;
                return oldValue;
            }
            else
                throw new InvalidOperationException("Increment can only be used with variables!");
        }

        public override IVecValue VisitBinaryMulDivMod([NotNull] VectorizeParser.BinaryMulDivModContext context)
        {
            var lhs = context.lhs.Accept(this);
            var rhs = context.rhs.Accept(this);

            switch (context.op.Text)
            {
                case "*": return lhs.Multiply(rhs);
                case "/": return lhs.Divide(rhs);
                case "%": return lhs.Modulo(rhs);
            }
            throw new InvalidOperationException($"Unknown operator '{context.op.Text}'");
        }

        public override IVecValue VisitBinaryAddSub([NotNull] VectorizeParser.BinaryAddSubContext context)
        {
            var lhs = context.lhs.Accept(this);
            var rhs = context.rhs.Accept(this);

            switch (context.op.Text)
            {
                case "+": return lhs.Add(rhs);
                case "-": return lhs.Subtract(rhs);
            }
            throw new InvalidOperationException($"Unknown operator '{context.op.Text}'");
        }

        public override IVecValue VisitLogRel([NotNull] VectorizeParser.LogRelContext context)
        {
            var lhs = context.lhs.Accept(this);
            var rhs = context.rhs.Accept(this);

            switch (context.op.Text)
            {
                case "<": return lhs.IsLesserThan(rhs);
                case "<=": return lhs.IsLesserOrEqualTo(rhs);
                case ">": return lhs.IsGreaterThan(rhs);
                case ">=": return lhs.IsGreaterOrEqualTo(rhs);
            }
            throw new InvalidOperationException($"Unknown operator '{context.op.Text}'");
        }

        public override IVecValue VisitLogEqual([NotNull] VectorizeParser.LogEqualContext context)
        {
            var lhs = context.lhs.Accept(this);
            var rhs = context.rhs.Accept(this);

            switch (context.op.Text)
            {
                case "==": return lhs.IsEqualTo(rhs);
                case "!=": return lhs.IsEqualTo(rhs).Not();
            }
            throw new InvalidOperationException($"Unknown operator '{context.op.Text}'");
        }

        public override IVecValue VisitLogAnd([NotNull] VectorizeParser.LogAndContext context)
        {
            var lhs = context.expression(0).Accept(this);
            var rhs = context.expression(1).Accept(this);
            if (lhs is VecBool lhsBool && rhs is VecBool rhsBool)
                return lhsBool.And(rhsBool);
            else
                throw new InvalidOperationException($"Both operants must be bools for AND!");
        }

        public override IVecValue VisitLogOr([NotNull] VectorizeParser.LogOrContext context)
        {
            var lhs = context.expression(0).Accept(this);
            var rhs = context.expression(1).Accept(this);
            if (lhs is VecBool lhsBool && rhs is VecBool rhsBool)
                return lhsBool.Or(rhsBool);
            else
                throw new InvalidOperationException($"Both operants must be bools for OR!");
        }

        public override IVecValue VisitLogNot([NotNull] VectorizeParser.LogNotContext context)
        {
            var value = context.expression().Accept(this);
            if (value is VecBool valueBool)
                return valueBool.Not();
            else
                throw new InvalidOperationException($"Operant must be bool for NOT!");
        }

        public override IVecValue VisitFunccall([NotNull] VectorizeParser.FunccallContext context)
        {
            var funcName = context.ID().GetText();
            var args = context.expression()
                .Select(expr => expr.Accept(this))
                .ToArray();

            if (builtInFunctions.ContainsKey(funcName))
                return builtInFunctions[funcName].Call(args, builtInFunctionContext);
            else
                return Run(funcName, args);
        }

        public override IVecValue VisitVar([NotNull] VectorizeParser.VarContext context)
        {
            var name = context.ID().GetText();
            return CurrentScope[name];
        }

        public override IVecValue VisitLiteralInt([NotNull] VectorizeParser.LiteralIntContext context)
        {
            string text = context.GetText();
            return new VecInt(text);
        }

        public override IVecValue VisitPara([NotNull] VectorizeParser.ParaContext context)
        {
            var value = context.expression().Accept(this);
            return value;
        }

        public override IVecValue VisitLiteralFloat([NotNull] VectorizeParser.LiteralFloatContext context)
        {
            string text = context.GetText();
            return new VecFloat(text);
        }

        public override IVecValue VisitLiteralBool([NotNull] VectorizeParser.LiteralBoolContext context)
        {
            string text = context.GetText();
            return new VecBool(text);
        }

        public override IVecValue VisitLiteralString([NotNull] VectorizeParser.LiteralStringContext context)
        {
            string text = context.GetText()
                .Trim('\"');
            return new VecString(text);
        }

        private IVecValue ConstructDefault(VecValueType type, int? size = null)
        {
            switch (type)
            {
                case VecValueType.Int:
                    if (size.HasValue)
                        return new VecArray<VecInt>(size.Value);
                    else
                        return new VecInt();
                case VecValueType.Float:
                    if (size.HasValue)
                        return new VecArray<VecFloat>(size.Value);
                    else
                        return new VecFloat();
                case VecValueType.Bool:
                    if (size.HasValue)
                        return new VecArray<VecBool>(size.Value);
                    else
                        return new VecBool();
                case VecValueType.String:
                    if (size.HasValue)
                        return new VecArray<VecString>(size.Value);
                    else
                        return new VecString();
                default:
                    throw new InvalidOperationException($"Can not construct type '{type}'!");
            }
        }

        private VecValueType ParseType(VectorizeParser.TypeContext context)
        {
            if (context == null)
                return VecValueType.Null;
            else
                return (VecValueType)Enum.Parse(typeof(VecValueType), context.GetText(), ignoreCase: true);
        }

        private class Scope
        {
            private readonly IDictionary<string, OneOf<IVecValue, Scope>> variables;

            public Scope(string name, Scope parent = null)
            {
                Name = parent != null
                    ? $"{parent.Name} - {name}"
                    : name;

                IsReturning = false;
                ReturnValue = VecNull.Value;

                variables = new Dictionary<string, OneOf<IVecValue, Scope>>();
                if (parent != null)
                {
                    foreach (var variable in parent.variables)
                        variables.Add(variable.Key, parent);
                }
            }

            public string Name { get; }
            public IVecValue ReturnValue { get; set; }
            public bool IsReturning { get; set; }

            public void DeclareVariable(string varName, IVecValue value)
            {
                if (variables.ContainsKey(varName))
                    throw new InvalidOperationException($"Variable '{varName}' already defined in scope '{Name}'!");
                variables[varName] = OneOf<IVecValue, Scope>.FromT0(value);
            }

            public void RemoveVariable(string varName)
            {
                if (!variables.ContainsKey(varName))
                    throw new InvalidOperationException($"Variable '{varName}' does not exist in scope  '{Name}'!");

                variables[varName].Switch(
                    _ => variables.Remove(varName),
                    scope => throw new InvalidOperationException($"Variable '{varName}' can not be removed in scope '{Name}' - must be in {scope.Name}!")
                );
            }

            public IVecValue this[string varName] {
                get {
                    if (variables.TryGetValue(varName, out var variable))
                        return variable.Match(
                            val => val,
                            scope => scope[varName]
                        );
                    else
                        throw new InvalidOperationException($"Variable '{varName}' does not exist in scope '{Name}'!");
                }
                set {
                    if (variables.TryGetValue(varName, out var variable))
                        variable.Switch(
                            _ => variables[varName] = OneOf<IVecValue, Scope>.FromT0(value),
                            scope => scope[varName] = value
                        );
                    else
                        throw new InvalidOperationException($"Variable '{varName}' does not exist in scope '{Name}'!");
                }
            }
        }
    }
}
