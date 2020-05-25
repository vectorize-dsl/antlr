using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class Setup : BuiltInFunction
    {
        public Setup()
            : base("setup") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 2)
                throw new InvalidOperationException("setup must be called with 2 args!");

            if (args[0] is VecInt width)
                if (args[1] is VecInt height)
                    context.AddSvgStart(width, height);
                else
                    throw new InvalidOperationException("setup: height must be int!");
            else
                throw new InvalidOperationException("setup: width must be int!");

            return VecNull.Value;
        }
    }
}
