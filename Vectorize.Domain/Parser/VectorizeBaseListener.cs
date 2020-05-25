//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ../../grammar/Vectorize.g4 by ANTLR 4.7.2

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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IVectorizeListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class VectorizeBaseListener : IVectorizeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] VectorizeParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] VectorizeParser.ProgramContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.function"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunction([NotNull] VectorizeParser.FunctionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.function"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunction([NotNull] VectorizeParser.FunctionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.funcparam"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFuncparam([NotNull] VectorizeParser.FuncparamContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.funcparam"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFuncparam([NotNull] VectorizeParser.FuncparamContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.funccall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunccall([NotNull] VectorizeParser.FunccallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.funccall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunccall([NotNull] VectorizeParser.FunccallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.vardef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVardef([NotNull] VectorizeParser.VardefContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.vardef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVardef([NotNull] VectorizeParser.VardefContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterType([NotNull] VectorizeParser.TypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitType([NotNull] VectorizeParser.TypeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] VectorizeParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] VectorizeParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.blockstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlockstmt([NotNull] VectorizeParser.BlockstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.blockstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlockstmt([NotNull] VectorizeParser.BlockstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.vardefstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVardefstmt([NotNull] VectorizeParser.VardefstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.vardefstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVardefstmt([NotNull] VectorizeParser.VardefstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.varassignstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVarassignstmt([NotNull] VectorizeParser.VarassignstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.varassignstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVarassignstmt([NotNull] VectorizeParser.VarassignstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.expressionstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpressionstmt([NotNull] VectorizeParser.ExpressionstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.expressionstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpressionstmt([NotNull] VectorizeParser.ExpressionstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.forstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterForstmt([NotNull] VectorizeParser.ForstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.forstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitForstmt([NotNull] VectorizeParser.ForstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.ifstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIfstmt([NotNull] VectorizeParser.IfstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.ifstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIfstmt([NotNull] VectorizeParser.IfstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.whilestmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWhilestmt([NotNull] VectorizeParser.WhilestmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.whilestmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWhilestmt([NotNull] VectorizeParser.WhilestmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="VectorizeParser.returnstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReturnstmt([NotNull] VectorizeParser.ReturnstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="VectorizeParser.returnstmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReturnstmt([NotNull] VectorizeParser.ReturnstmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>LiteralFloat</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteralFloat([NotNull] VectorizeParser.LiteralFloatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>LiteralFloat</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteralFloat([NotNull] VectorizeParser.LiteralFloatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>LogEqual</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLogEqual([NotNull] VectorizeParser.LogEqualContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>LogEqual</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLogEqual([NotNull] VectorizeParser.LogEqualContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>LiteralBool</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteralBool([NotNull] VectorizeParser.LiteralBoolContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>LiteralBool</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteralBool([NotNull] VectorizeParser.LiteralBoolContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>LiteralString</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteralString([NotNull] VectorizeParser.LiteralStringContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>LiteralString</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteralString([NotNull] VectorizeParser.LiteralStringContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>Para</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPara([NotNull] VectorizeParser.ParaContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Para</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPara([NotNull] VectorizeParser.ParaContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>LogOr</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLogOr([NotNull] VectorizeParser.LogOrContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>LogOr</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLogOr([NotNull] VectorizeParser.LogOrContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>Var</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVar([NotNull] VectorizeParser.VarContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Var</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVar([NotNull] VectorizeParser.VarContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryAddSub</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinaryAddSub([NotNull] VectorizeParser.BinaryAddSubContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryAddSub</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinaryAddSub([NotNull] VectorizeParser.BinaryAddSubContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>LogRel</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLogRel([NotNull] VectorizeParser.LogRelContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>LogRel</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLogRel([NotNull] VectorizeParser.LogRelContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>LiteralInt</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteralInt([NotNull] VectorizeParser.LiteralIntContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>LiteralInt</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteralInt([NotNull] VectorizeParser.LiteralIntContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>Unary</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnary([NotNull] VectorizeParser.UnaryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Unary</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnary([NotNull] VectorizeParser.UnaryContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryMulDivMod</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinaryMulDivMod([NotNull] VectorizeParser.BinaryMulDivModContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryMulDivMod</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinaryMulDivMod([NotNull] VectorizeParser.BinaryMulDivModContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>LogAnd</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLogAnd([NotNull] VectorizeParser.LogAndContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>LogAnd</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLogAnd([NotNull] VectorizeParser.LogAndContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>FuncCall</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFuncCall([NotNull] VectorizeParser.FuncCallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>FuncCall</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFuncCall([NotNull] VectorizeParser.FuncCallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>ArrayAccess</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArrayAccess([NotNull] VectorizeParser.ArrayAccessContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>ArrayAccess</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArrayAccess([NotNull] VectorizeParser.ArrayAccessContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>LogNot</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLogNot([NotNull] VectorizeParser.LogNotContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>LogNot</c>
	/// labeled alternative in <see cref="VectorizeParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLogNot([NotNull] VectorizeParser.LogNotContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace Vectorize.Domain.Parser