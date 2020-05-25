using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Vectorize.Domain;
using System.Globalization;

namespace Vectorize.Interpreter
{
    public abstract class BuiltInFunction : ICallableVecFunction<BuiltInFunctionContext>
    {
        static BuiltInFunction()
        {
            List = typeof(BuiltInFunction).Assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(BuiltInFunction)))
                .Select(t => (BuiltInFunction)Activator.CreateInstance(t))
                .ToArray();
        }

        public static BuiltInFunction[] List { get; }

        protected BuiltInFunction(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract IVecValue Call(IVecValue[] args, BuiltInFunctionContext context);
    }

    public class BuiltInFunctionContext
    {
        private readonly State state;

        public BuiltInFunctionContext(State state)
        {
            this.state = state;
        }

        public void AddSvgStart(VecInt width, VecInt height)
        {
            state.Output.AppendLine(FormattableString.Invariant(
                $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{width.Value}\" height=\"{height.Value}\">"
            ));
        }

        public void AddSvgElement(string elemName, params (string name, IVecValue value)[] attrs)
            => AddSvgElement(elemName, attrs.AsEnumerable());
        public void AddSvgElement(string elemName, bool includeStyleAttrs, params (string name, IVecValue value)[] attrs)
            => AddSvgElement(elemName, attrs.AsEnumerable(), includeStyleAttrs);
        public void AddSvgElement(string elemName, bool includeStyleAttrs, IVecValue content, params (string name, IVecValue value)[] attrs)
            => AddSvgElement(elemName, attrs.AsEnumerable(), includeStyleAttrs, content);

        public void AddSvgElement(string elemName, IEnumerable<(string name, IVecValue value)> attrs, bool includeStyleAttrs = false, IVecValue content = null)
        {
            if (includeStyleAttrs)
            {
                if (elemName != "text" && state.StrokeColor != null)
                    attrs = attrs.Concat(new (string, IVecValue)[] {
                        ("stroke", new VecString(state.StrokeColor))
                    });
                if (elemName != "text" && state.StrokeWidth.HasValue)
                    attrs = attrs.Concat(new (string, IVecValue)[] {
                        ("stroke-width", new VecFloat(state.StrokeWidth.Value))
                    });
                if (state.FillColor != null)
                    attrs = attrs.Concat(new (string, IVecValue)[] {
                        ("fill", new VecString(state.FillColor))
                    });
                if (elemName == "text" && state.FontSize != null)
                    attrs = attrs.Concat(new (string, IVecValue)[] {
                        ("font-size", new VecInt(state.FontSize.Value))
                    });
            }

            var sb = new StringBuilder();
            sb.Append("<");
            sb.Append(elemName);
            foreach (var (name, value) in attrs)
            {
                sb.Append(" ");
                sb.Append(name);
                sb.Append("=\"");
                sb.Append(ToStringInv(value));
                sb.Append("\"");
            }
            if (content == null)
            {
                sb.AppendLine(" />");
            }
            else
            {
                sb.Append(">");
                sb.Append(ToStringInv(content));
                sb.Append("</");
                sb.Append(elemName);
                sb.AppendLine(">");
            }

            state.Output.AppendLine(sb.ToString());
        }

        public void SetStyle(
            string fill = null,
            string stroke = null, float? strokeWidth = null,
            int? fontSize = null)
        {
            if (fill != null)
                state.FillColor = fill;
            if (stroke != null)
                state.StrokeColor = stroke;
            if (strokeWidth != null)
                state.StrokeWidth = strokeWidth;
            if (fontSize != null)
                state.FontSize = fontSize;
        }

        private string ToStringInv(IVecValue value)
        {
            switch (value)
            {
                case VecInt vInt:
                    return vInt.Value.ToString("#", CultureInfo.InvariantCulture);
                case VecFloat vFlaot:
                    return vFlaot.Value.ToString("0.#", CultureInfo.InvariantCulture);
                case VecString vStr:
                    return vStr.Value.ToString();
                case VecBool vBool:
                    return vBool.Value.ToString(CultureInfo.InvariantCulture);
            }
            throw new ArgumentException($"Unknown type of value {value.Type}!", nameof(value));
        }
    }
}
