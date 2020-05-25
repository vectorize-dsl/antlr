using Antlr4.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Vectorize.Domain.Parser;

namespace Vectorize.Interpreter
{
    public class Interpreter
    {
        public Result Run(FileInfo file)
        {
            using (var stream = file.OpenRead())
            {
                return new Context(stream).Execute();
            }
        }

        public Result Run(string code)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(code)))
            {
                return new Context(stream).Execute();
            }
        }

        private class Context : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
        {
            private readonly Stream stream;
            private readonly List<string> syntaxErrors;

            public Context(Stream stream)
            {
                this.stream = stream;
                syntaxErrors = new List<string>();
            }

            public Result Execute()
            {
                var input = new AntlrInputStream(stream);
                var lexer = new VectorizeLexer(input);
                lexer.AddErrorListener(this);

                var tokens = new CommonTokenStream(lexer);
                var parser = new VectorizeParser(tokens);
                parser.AddErrorListener(this);

                var state = new State();
                var program = parser.program();
                if (!syntaxErrors.Any())
                {
                    state.Run(program);
                    return state.ToResult();
                }
                else
                {
                    return new Result("", syntaxErrors);
                }
            }

            public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                syntaxErrors.Add($"{line}:{charPositionInLine}: {msg}");
            }

            public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                syntaxErrors.Add($"{line}:{charPositionInLine}: {msg}");
            }
        }
    }
}
