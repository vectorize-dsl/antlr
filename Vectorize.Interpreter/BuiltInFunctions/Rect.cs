using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class Rect : BuiltInFunction
    {
        public Rect()
            : base("rect") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 4)
                throw new InvalidOperationException("rect must be called with 4 args!");

            if (args[0].TryConvertToFloat(out var x))
                if (args[1].TryConvertToFloat(out var y))
                    if (args[2].TryConvertToFloat(out var width))
                        if (args[3].TryConvertToFloat(out var height))
                        {
                            context.AddSvgElement("rect", includeStyleAttrs: true,
                                ("x", x),
                                ("y", y),
                                ("width", width),
                                ("height", height)
                            );
                        }
                        else
                            throw new InvalidOperationException("rect: height must be int or float!");
                    else
                        throw new InvalidOperationException("rect: width must be int or float!");
                else
                    throw new InvalidOperationException("rect: y must be int or float!");
            else
                throw new InvalidOperationException("rect: x must be int or float!");

            return VecNull.Value;
        }
    }
}
