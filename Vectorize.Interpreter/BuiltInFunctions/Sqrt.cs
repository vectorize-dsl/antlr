using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class Sqrt : BuiltInFunction
    {
        public Sqrt()
            : base("sqrt") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 1)
                throw new InvalidOperationException("toString must be called with 1 arg!");

            if (args[0].TryConvertToFloat(out var value))
                return new VecFloat((float)Math.Sqrt(value.Value));
            else
                throw new InvalidOperationException("sqrt: value must be int or float!");
        }
    }
}
