using System;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class Length : BuiltInFunction
    {
        public Length()
            : base("length") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 1)
                throw new InvalidOperationException("length must be called with one argument!");

            if (args[0] is IVecContainer container)
                return new VecInt(container.Size);
            else
                throw new InvalidOperationException("length: value must be an array!");
        }
    }
}
