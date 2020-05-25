using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class SetFontSize : BuiltInFunction
    {
        public SetFontSize()
            : base("setFontSize") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 1)
                throw new InvalidOperationException("setFontSize must be called with 1 arg!");

            if (args[0] is VecInt size)
                context.SetStyle(fontSize: size.Value);
            else
                throw new InvalidOperationException("setFontSize: size must be int!");
            return VecNull.Value;
        }
    }
}
