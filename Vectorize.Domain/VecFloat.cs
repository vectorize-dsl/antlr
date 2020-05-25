using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Vectorize.Domain
{
    [DebuggerDisplay("VecFloat {Value}")]
    public struct VecFloat : IVecValue, IEquatable<VecFloat>
    {
        public readonly float Value;

        public VecFloat(float value)
        {
            Value = value;
        }

        public VecFloat(string str)
        {
            Value = float.Parse(str, CultureInfo.InvariantCulture);
        }

        public VecValueType Type => VecValueType.Float;

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
                    return new VecFloat(Value + otherInt.Value);
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
                    return new VecFloat(Value - otherInt.Value);
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
                    return new VecFloat(Value * otherInt.Value);
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
                    return new VecFloat(Value / otherInt.Value);
                case VecFloat otherFloat:
                    return new VecFloat(Value / otherFloat.Value);
                default:
                    throw new InvalidOperationException($"Can only multiply numeric type! Type: {other.Type}");
            }
        }

        public IVecValue Modulo(IVecValue other)
        {
            switch (other)
            {
                case VecInt otherInt:
                    return new VecFloat(Value % otherInt.Value);
                case VecFloat otherFloat:
                    return new VecFloat(Value % otherFloat.Value);
                default:
                    throw new InvalidOperationException($"Can only multiply numeric type! Type: {other.Type}");
            }
        }

        public override bool Equals(object obj)
            => obj is VecFloat @float && Equals(@float);
        public bool Equals(VecFloat other) 
            => Value == other.Value;
        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => $"{Value}: float";
    }
}
