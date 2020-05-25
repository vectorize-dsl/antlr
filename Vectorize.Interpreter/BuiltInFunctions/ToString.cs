using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class ToString : BuiltInFunction
    {
        public ToString()
            : base("toString") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 1)
                throw new InvalidOperationException("toString must be called with 1 arg!");

            if (args[0] is VecInt valueI)
                return new VecString(valueI.Value.ToString());
            else if (args[0] is VecFloat valueF)
                return new VecString(valueF.Value.ToString());
            else if (args[0] is VecBool valueB)
                return new VecString(valueB.Value.ToString());
            else if (args[0] is VecString valueS)
                return valueS;
            else
                throw new InvalidOperationException("toString: null not supported!");
        }
    }
}
