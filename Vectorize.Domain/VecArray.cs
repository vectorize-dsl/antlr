using System;
using System.Diagnostics;
using System.Linq;

namespace Vectorize.Domain
{
    [DebuggerDisplay("VecArray {Values}")]
    public struct VecArray<T> : IVecContainer, IEquatable<VecArray<T>> where T : IVecValue
    {
        public readonly T[] Values;

        public VecArray(int size)
        {
            Values = new T[size];
        }

        public VecValueType Type => VecValueType.Array;
        public VecValueType ElementType => VecTypeMapping.FromType[typeof(T)];

        public int Size => Values?.Length ?? 0;

        public IVecValue Get(int idx)
        {
            if (idx < 0 || idx >= Size)
                throw new InvalidOperationException($"Index must be between 0 and {Values.Length - 1}!");
            return Values[idx];
        }

        public void Set(int idx, IVecValue value)
        {
            if (idx < 0 || idx >= Size)
                throw new InvalidOperationException($"Index must be between 0 and {Values.Length - 1}!");

            if (value is T valueT)
                Values[idx] = valueT;
            else
                throw new InvalidOperationException($"Wrong element type for this {ElementType} array! Was: {value.Type}");

        }

        public VecBool IsEqualTo(IVecValue other)
        {
            switch (other)
            {
                case VecArray<T> otherArray:
                    return new VecBool(Values.SequenceEqual(otherArray.Values));
                default:
                    throw new InvalidOperationException($"Can only equal with string type! Type: {other.Type}");
            }
        }

        public VecBool IsLesserThan(IVecValue other)
            => throw new InvalidOperationException("Array does not support relational operations!");

        public IVecValue Add(IVecValue other)
            => throw new InvalidOperationException("Array does not support numeric operations!");
        public IVecValue Subtract(IVecValue other)
            => throw new InvalidOperationException("Array does not support numeric operations!");
        public IVecValue Multiply(IVecValue other)
            => throw new InvalidOperationException("Array does not support numeric operations!");
        public IVecValue Divide(IVecValue other)
            => throw new InvalidOperationException("Array does not support numeric operations!");
        public IVecValue Modulo(IVecValue other)
            => throw new InvalidOperationException("Array does not support numeric operations!");

        public override bool Equals(object obj)
            => obj is VecArray<T> array && Equals(array);
        public bool Equals(VecArray<T> other)
            => Values.SequenceEqual(other.Values);
        public override int GetHashCode()
            => Values.GetHashCode();

        public override string ToString()
            => $"[{string.Join(", ", Values.Select(v => v.ToString()))}]: array<{ElementType}>";
    }
}
