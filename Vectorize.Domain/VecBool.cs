using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Vectorize.Domain
{
    [DebuggerDisplay("VecBool {Value}")]
    public struct VecBool : IVecValue, IEquatable<VecBool>
    {
        public readonly bool Value;

        public VecBool(bool value)
        {
            Value = value;
        }

        public VecBool(string str)
        {
            Value = bool.Parse(str);
        }

        public VecValueType Type => VecValueType.Bool;

        public VecBool IsEqualTo(IVecValue other)
        {
            switch (other)
            {
                case VecBool otherBool:
                    return new VecBool(Value == otherBool.Value);
                default:
                    throw new InvalidOperationException($"Can only equal with bools! Type: {other.Type}");
            }
        }
        public VecBool IsLesserThan(IVecValue other)
            => throw new InvalidOperationException("Bool does not support relational operations!");

        public VecBool Or(VecBool other)
            => new VecBool(Value || other.Value);
        public VecBool And(VecBool other)
            => new VecBool(Value && other.Value);
        public VecBool Not()
            => new VecBool(!Value);

        public IVecValue Add(IVecValue other)
            => throw new InvalidOperationException("Bool does not support numeric operations!");
        public IVecValue Subtract(IVecValue other)
            => throw new InvalidOperationException("Bool does not support numeric operations!");
        public IVecValue Multiply(IVecValue other)
            => throw new InvalidOperationException("Bool does not support numeric operations!");
        public IVecValue Divide(IVecValue other)
            => throw new InvalidOperationException("Bool does not support numeric operations!");
        public IVecValue Modulo(IVecValue other)
            => throw new InvalidOperationException("Bool does not support numeric operations!");

        public override bool Equals(object obj)
            => obj is VecBool @bool && Equals(@bool);
        public bool Equals(VecBool other)
            => Value == other.Value;
        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => $"{Value}: bool";
    }
}
