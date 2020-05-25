using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class SetStrokeWidth : BuiltInFunction
    {
        public SetStrokeWidth()
            : base("setStrokeWidth") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 1)
                throw new InvalidOperationException("setStrokeWidth must be called with 1 arg!");

            if (args[0].TryConvertToFloat(out var width))
                context.SetStyle(strokeWidth: width.Value);
            else
                throw new InvalidOperationException("setStrokeWidth: width must be int or float!");
            return VecNull.Value;
        }
    }
}
