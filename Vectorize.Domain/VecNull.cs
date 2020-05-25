using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Vectorize.Domain
{
    [DebuggerDisplay("VecNull")]
    public struct VecNull : IVecValue, IEquatable<VecNull>
    {
        public static readonly VecNull Value = new VecNull();

        public VecValueType Type => VecValueType.Null;

        public VecBool IsEqualTo(IVecValue other)
        {
            switch (other)
            {
                case VecNull _:
                    return new VecBool(true);
                default:
                    throw new InvalidOperationException($"Can only equal with null type! Type: {other.Type}");
            }
        }

        public VecBool IsLesserThan(IVecValue other)
            => throw new InvalidOperationException("Null does not support relational operations!");

        public IVecValue Add(IVecValue other)
            => throw new InvalidOperationException("Null does not support numeric operations!");
        public IVecValue Subtract(IVecValue other)
            => throw new InvalidOperationException("Null does not support numeric operations!");
        public IVecValue Multiply(IVecValue other)
            => throw new InvalidOperationException("Null does not support numeric operations!");
        public IVecValue Divide(IVecValue other)
            => throw new InvalidOperationException("Null does not support numeric operations!");
        public IVecValue Modulo(IVecValue other)
            => throw new InvalidOperationException("Null does not support numeric operations!");

        public override bool Equals(object obj)
            => obj is VecNull;
        public bool Equals(VecNull other)
            => other.Type == VecValueType.Null;
        public override int GetHashCode()
            => 0;

        public override string ToString()
            => $"null: null";
    }
}
