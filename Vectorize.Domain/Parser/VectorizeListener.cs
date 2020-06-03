//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ../grammar/Vectorize.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Vectorize.Domain.Parser {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="VectorizeParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IVectorizeListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] VectorizeParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] VectorizeParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction([NotNull] VectorizeParser.FunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction([NotNull] VectorizeParser.FunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.funcparam"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncparam([NotNull] VectorizeParser.FuncparamContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.funcparam"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncparam([NotNull] VectorizeParser.FuncparamContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.funccall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunccall([NotNull] VectorizeParser.FunccallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.funccall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunccall([NotNull] VectorizeParser.FunccallContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.vardef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVardef([NotNull] VectorizeParser.VardefContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.vardef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVardef([NotNull] VectorizeParser.VardefContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterType([NotNull] VectorizeParser.TypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitType([NotNull] VectorizeParser.TypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] VectorizeParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] VectorizeParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.blockstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlockstmt([NotNull] VectorizeParser.BlockstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.blockstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlockstmt([NotNull] VectorizeParser.BlockstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.vardefstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVardefstmt([NotNull] VectorizeParser.VardefstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.vardefstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVardefstmt([NotNull] VectorizeParser.VardefstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.varassignstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVarassignstmt([NotNull] VectorizeParser.VarassignstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.varassignstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVarassignstmt([NotNull] VectorizeParser.VarassignstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.expressionstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressionstmt([NotNull] VectorizeParser.ExpressionstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.expressionstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressionstmt([NotNull] VectorizeParser.ExpressionstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.forstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForstmt([NotNull] VectorizeParser.ForstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.forstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForstmt([NotNull] VectorizeParser.ForstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.ifstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfstmt([NotNull] VectorizeParser.IfstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.ifstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfstmt([NotNull] VectorizeParser.IfstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.whilestmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhilestmt([NotNull] VectorizeParser.WhilestmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.whilestmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhilestmt([NotNull] VectorizeParser.WhilestmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.returnstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnstmt([NotNull] VectorizeParser.ReturnstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.returnstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnstmt([NotNull] VectorizeParser.ReturnstmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LiteralFloat</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralFloat([NotNull] VectorizeParser.LiteralFloatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LiteralFloat</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralFloat([NotNull] VectorizeParser.LiteralFloatContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LogEqual</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogEqual([NotNull] VectorizeParser.LogEqualContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LogEqual</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogEqual([NotNull] VectorizeParser.LogEqualContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LiteralBool</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralBool([NotNull] VectorizeParser.LiteralBoolContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LiteralBool</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralBool([NotNull] VectorizeParser.LiteralBoolContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LiteralString</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralString([NotNull] VectorizeParser.LiteralStringContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LiteralString</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralString([NotNull] VectorizeParser.LiteralStringContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Para</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPara([NotNull] VectorizeParser.ParaContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Para</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPara([NotNull] VectorizeParser.ParaContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LogOr</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogOr([NotNull] VectorizeParser.LogOrContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LogOr</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogOr([NotNull] VectorizeParser.LogOrContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Var</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVar([NotNull] VectorizeParser.VarContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Var</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVar([NotNull] VectorizeParser.VarContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryAddSub</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinaryAddSub([NotNull] VectorizeParser.BinaryAddSubContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryAddSub</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinaryAddSub([NotNull] VectorizeParser.BinaryAddSubContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LogRel</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogRel([NotNull] VectorizeParser.LogRelContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LogRel</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogRel([NotNull] VectorizeParser.LogRelContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LiteralInt</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralInt([NotNull] VectorizeParser.LiteralIntContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LiteralInt</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralInt([NotNull] VectorizeParser.LiteralIntContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>Unary</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnary([NotNull] VectorizeParser.UnaryContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Unary</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnary([NotNull] VectorizeParser.UnaryContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryMulDivMod</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinaryMulDivMod([NotNull] VectorizeParser.BinaryMulDivModContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryMulDivMod</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinaryMulDivMod([NotNull] VectorizeParser.BinaryMulDivModContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LogAnd</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogAnd([NotNull] VectorizeParser.LogAndContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LogAnd</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogAnd([NotNull] VectorizeParser.LogAndContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>FuncCall</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncCall([NotNull] VectorizeParser.FuncCallContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>FuncCall</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncCall([NotNull] VectorizeParser.FuncCallContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>ArrayAccess</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayAccess([NotNull] VectorizeParser.ArrayAccessContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ArrayAccess</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayAccess([NotNull] VectorizeParser.ArrayAccessContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LogNot</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogNot([NotNull] VectorizeParser.LogNotContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LogNot</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogNot([NotNull] VectorizeParser.LogNotContext context);
}
} // namespace Vectorize.Domain.Parser
