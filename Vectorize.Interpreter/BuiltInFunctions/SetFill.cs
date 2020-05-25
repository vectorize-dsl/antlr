using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class SetFill : BuiltInFunction
    {
        public SetFill()
            : base("setFill") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 1)
                throw new InvalidOperationException("setFill must be called with 1 arg!");

            if (args[0] is VecString color)
                context.SetStyle(fill: color.Value);
            else
                throw new InvalidOperationException("setFill: color must be string!");
            return VecNull.Value;
        }
    }
}
