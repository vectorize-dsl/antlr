using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vectorize.Domain
{
    public interface IVecValue
    {
        VecValueType Type { get; }

        VecBool IsEqualTo(IVecValue other);
        VecBool IsLesserThan(IVecValue other);

        IVecValue Add(IVecValue other);
        IVecValue Subtract(IVecValue other);
        IVecValue Multiply(IVecValue other);
        IVecValue Divide(IVecValue other);
        IVecValue Modulo(IVecValue other);
    }

    public interface IVecContainer : IVecValue
    {
        VecValueType ElementType { get; }

        int Size { get; }

        IVecValue Get(int idx);

        void Set(int idx, IVecValue value);
    }

    public enum VecValueType
    {
        Null,
        Int,
        Float,
        Bool,
        String,
        Array
    }

    public static class VecTypeMapping
    {
        public static Dictionary<VecValueType, Type> FromEnum = new Dictionary<VecValueType, Type>() {
            { VecValueType.Null, typeof(VecNull) },
            { VecValueType.Int, typeof(VecInt) },
            { VecValueType.Float, typeof(VecFloat) },
            { VecValueType.Bool, typeof(VecBool) },
            { VecValueType.String, typeof(VecString) },
            { VecValueType.Array, typeof(VecArray<>) },
        };
        public static Dictionary<Type, VecValueType> FromType = FromEnum
            .ToDictionary(kp => kp.Value, kp => kp.Key);
    }

    public static class VecValueExtensions
    {
        public static VecBool IsGreaterThan(this IVecValue lhs, IVecValue rhs)
            => lhs.IsLesserThan(rhs).Not();
        public static VecBool IsGreaterOrEqualTo(this IVecValue lhs, IVecValue rhs)
            => lhs.IsEqualTo(rhs).Or(lhs.IsGreaterThan(rhs));

        public static VecBool IsLesserOrEqualTo(this IVecValue lhs, IVecValue rhs)
            => lhs.IsEqualTo(rhs).Or(lhs.IsLesserThan(rhs));

        public static bool TryConvertToFloat(this IVecValue value, out VecFloat valueAsFloat)
        {
            if (value is VecFloat valF)
            {
                valueAsFloat = valF;
                return true;
            }
            if (value is VecInt valI)
            {
                valueAsFloat = new VecFloat(valI.Value);
                return true;
            }

            valueAsFloat = default(VecFloat);
            return false;
        }
    }
}
