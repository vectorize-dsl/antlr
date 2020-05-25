using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class SetStroke : BuiltInFunction
    {
        public SetStroke()
            : base("setStroke") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 1)
                throw new InvalidOperationException("setStroke must be called with 1 arg!");

            if (args[0] is VecString color)
                context.SetStyle(stroke: color.Value);
            else
                throw new InvalidOperationException("setStroke: color must be string!");
            return VecNull.Value;
        }
    }
}
