using System;

namespace DeclarativeCSharp.Fluency
{
    public static class ControlExtensions
    {
        public static TTo Apply<TFrom, TTo>(this TFrom @this, Func<TFrom, TTo> transformation)
            => transformation(@this);

        public static TTo Apply<TFrom1, TFrom2, TTo>(this (TFrom1, TFrom2) @this, Func<TFrom1, TFrom2, TTo> transformation)
            => transformation(@this.Item1, @this.Item2);

        public static (TThis left, TNew right) Join<TThis, TNew>(this TThis @this, TNew @new)
            => (@this, @new);

        public static TFrom? NullIf<TFrom>(this TFrom @this, Func<TFrom, bool> caseToNullify) where TFrom : struct
            => caseToNullify(@this) ? null : @this;
    }
}
