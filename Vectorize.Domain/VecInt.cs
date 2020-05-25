using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Vectorize.Domain
{
    [DebuggerDisplay("VecInt {Value}")]
    public struct VecInt : IVecValue, IEquatable<VecInt>
    {
        public static readonly VecInt Zero = new VecInt(0);
        public static readonly VecInt One = new VecInt(1);
        public readonly int Value;

        public VecInt(int value)
        {
            Value = value;
        }

        public VecInt(string str)
        {
            Value = int.Parse(str, CultureInfo.InvariantCulture);
        }

        public VecValueType Type => VecValueType.Int;

        public VecBool IsEqualTo(IVecValue other)
        {
            switch (other)
            {
                case VecInt otherInt:
                    return new VecBool(Value == otherInt.Value);
                case VecFloat otherFloat:
                    return new VecBool(Value == otherFloat.Value);
                default:
                    throw new InvalidOperationException($"Can only equal with numeric type! Type: {other.Type}");
            }
        }

        public VecBool IsLesserThan(IVecValue other)
        {
            switch (other)
            {
                case VecInt otherInt:
                    return new VecBool(Value < otherInt.Value);
                case VecFloat otherFloat:
                    return new VecBool(Value < otherFloat.Value);
                default:
                    throw new InvalidOperationException($"Can only compare with numeric type! Type: {other.Type}");
            }
        }

        public IVecValue Add(IVecValue other)
        {
            switch (other)
            {
                case VecInt otherInt:
                    return new VecInt(Value + otherInt.Value);
                case VecFloat otherFloat:
                    return new VecFloat(Value + otherFloat.Value);
                default:
                    throw new InvalidOperationException($"Can only add numeric type! Type: {other.Type}");
            }
        }

        public IVecValue Subtract(IVecValue other)
        {
            switch (other)
            {
                case VecInt otherInt:
                    return new VecInt(Value - otherInt.Value);
                case VecFloat otherFloat:
                    return new VecFloat(Value - otherFloat.Value);
                default:
                    throw new InvalidOperationException($"Can only subtract numeric type! Type: {other.Type}");
            }
        }

        public IVecValue Multiply(IVecValue other)
        {
            switch (other)
            {
                case VecInt otherInt:
                    return new VecInt(Value * otherInt.Value);
                case VecFloat otherFloat:
                    return new VecFloat(Value * otherFloat.Value);
                default:
                    throw new InvalidOperationException($"Can only multiply numeric type! Type: {other.Type}");
            }
        }

        public IVecValue Divide(IVecValue other)
        {
            switch (other)
            {
                case VecInt otherInt:
                    return new VecInt(Value / otherInt.Value);
                case VecFloat otherFloat:
                    return new VecFloat(Value / otherFloat.Value);
                default:
                    throw new InvalidOperationException($"Can only divide numeric type! Type: {other.Type}");
            }
        }

        public IVecValue Modulo(IVecValue other)
        {
            switch (other)
            {
                case VecInt otherInt:
                    return new VecInt(Value % otherInt.Value);
                case VecFloat otherFloat:
                    return new VecFloat(Value % otherFloat.Value);
                default:
                    throw new InvalidOperationException($"Can only apply modulo to numeric type! Type: {other.Type}");
            }
        }

        public override bool Equals(object obj)
            => obj is VecInt @int && Equals(@int);
        public bool Equals(VecInt other)
            => Value == other.Value;
        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => $"{Value}: int";
    }
}
