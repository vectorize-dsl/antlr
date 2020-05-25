using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Vectorize.Domain
{
    [DebuggerDisplay("VecString {Value}")]
    public struct VecString : IVecValue, IEquatable<VecString>
    {
        public readonly string Value;

        public VecString(string value)
        {
            Value = value;
        }

        public VecValueType Type => VecValueType.String;

        public VecBool IsEqualTo(IVecValue other)
        {
            switch (other)
            {
                case VecString otherString:
                    return new VecBool(Value == otherString.Value);
                default:
                    throw new InvalidOperationException($"Can only equal with string type! Type: {other.Type}");
            }
        }

        public VecBool IsLesserThan(IVecValue other)
            => throw new InvalidOperationException("String does not support relational operations!");

        public IVecValue Add(IVecValue other)
            => throw new InvalidOperationException("String does not support numeric operations!");
        public IVecValue Subtract(IVecValue other)
            => throw new InvalidOperationException("String does not support numeric operations!");
        public IVecValue Multiply(IVecValue other)
            => throw new InvalidOperationException("String does not support numeric operations!");
        public IVecValue Divide(IVecValue other)
            => throw new InvalidOperationException("String does not support numeric operations!");
        public IVecValue Modulo(IVecValue other)
            => throw new InvalidOperationException("String does not support numeric operations!");

        public override bool Equals(object obj)
            => obj is VecString @string && Equals(@string);
        public bool Equals(VecString other)
            => Value == other.Value;
        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => $"\"{Value}\": string";
    }
}
