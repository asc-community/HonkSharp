using System;

namespace DeclarativeCSharp.Fluency
{
    public static class ControlExtensions
    {
        public static TTo Map<TFrom, TTo>(this TFrom @this, Func<TFrom, TTo> transformation)
            => transformation(@this);

        public delegate TReturn OneInOneOut<TIn, TOut, TReturn>(TIn arg, out TOut outArg);
        public static (TTo, TOut) Map<TFrom, TOut, TTo>(this TFrom @this, OneInOneOut<TFrom, TOut, TTo> transformation)
            => transformation(@this, out var res).Inject(res);

        public static TTo Apply<TFrom1, TFrom2, TTo>(this (TFrom1, TFrom2) @this, Func<TFrom1, TFrom2, TTo> transformation)
            => transformation(@this.Item1, @this.Item2);

        public static (TThis Current, TNew Injected) Inject<TThis, TNew>(this TThis @this, TNew @new)
            => new(@this, @new);

        public static TFrom? NullIf<TFrom>(this TFrom @this, Func<TFrom, bool> caseToNullify) where TFrom : struct
            => caseToNullify(@this) ? null : @this;

        public static T Alias<T>(this T @this, out T alias)
            => alias = @this;

        public static T Let<T, TOut>(this T @this, out TOut alias, TOut value)
            => value
                .Alias(out alias)
                .Inject(@this)
                .Injected;

        // public static T StoreAs<T>(
    }
}
