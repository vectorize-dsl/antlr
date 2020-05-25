using System.Collections.Generic;
using System.Linq;

namespace Vectorize.Interpreter
{
    public class Result
    {
        public Result(string output, IList<string> errors = null)
        {
            Output = output;
            Errors = errors ?? new List<string>();
        }

        public string Output { get; }
        public IList<string> Errors { get; }
        public bool IsSuccess => !Errors.Any();
    }
}
