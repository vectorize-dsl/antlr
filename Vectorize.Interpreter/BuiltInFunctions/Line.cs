using System;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;

namespace Vectorize.Interpreter.BuiltInFunctions
{
    public class Line : BuiltInFunction
    {
        public Line()
            : base("line") { }

        public override IVecValue Call(IVecValue[] args, BuiltInFunctionContext context)
        {
            if (args.Length != 4)
                throw new InvalidOperationException("line must be called with 4 args!");

            if (args[0].TryConvertToFloat(out var x1))
                if (args[1].TryConvertToFloat(out var y1))
                    if (args[2].TryConvertToFloat(out var x2))
                        if (args[3].TryConvertToFloat(out var y2))
                        {
                            context.AddSvgElement("line", includeStyleAttrs: true,
                                ("x1", x1),
                                ("y1", y1),
                                ("x2", x2),
                                ("y2", y2)
                            );
                        }
                        else
                            throw new InvalidOperationException("line: y2 must be int or float!");
                    else
                        throw new InvalidOperationException("line: x2 must be int or float!");
                else
                    throw new InvalidOperationException("line: y1 must be int or float!");
            else
                throw new InvalidOperationException("line: x1 must be int or float!");

            return VecNull.Value;
        }
    }
}
