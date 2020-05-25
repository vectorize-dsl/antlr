using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class Text : BuiltInFunction
    {
        public Text()
            : base("text") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 3)
                throw new InvalidOperationException("text must be called with 3 args!");

            if (args[0].TryConvertToFloat(out var x))
                if (args[1].TryConvertToFloat(out var y))
                    if (args[2] is VecString text)
                    {
                        context.AddSvgElement("text",
                            includeStyleAttrs: true,
                            content: text,
                            ("x", x),
                            ("y", y)
                        );
                    }
                    else
                        throw new InvalidOperationException("text: text must be string!");
                else
                    throw new InvalidOperationException("text: y must be int!");
            else
                throw new InvalidOperationException("text: x must be int!");

            return VecNull.Value;
        }
    }
}
