using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class Circle : BuiltInFunction
    {
        public Circle()
            : base("circle") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 3)
                throw new InvalidOperationException("circle must be called with 3 args!");

            if (args[0].TryConvertToFloat(out var cx))
                if (args[1].TryConvertToFloat(out var cy))
                    if (args[2].TryConvertToFloat(out var radius))
                    {
                        context.AddSvgElement("circle", includeStyleAttrs: true,
                            ("cx", cx),
                            ("cy", cy),
                            ("r", radius)
                        );
                    }
                    else
                        throw new InvalidOperationException("circle: radius must be int or float!");
                else
                    throw new InvalidOperationException("circle: cy must be int or float!");
            else
                throw new InvalidOperationException("circle: cx must be int or float!");

            return VecNull.Value;
        }
    }
}
