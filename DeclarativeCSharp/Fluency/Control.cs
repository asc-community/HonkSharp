using System;

namespace DeclarativeCSharp.Fluency
{
    public static class ControlExtensions
    {
        public static TTo Map<TFrom, TTo>(this TFrom @this, Func<TFrom, TTo> transformation)
            => transformation(@this);

        public delegate TReturn OneInOneOut<TIn, TOut, TReturn>(TIn arg, out TOut outArg);
        public static TTo Map<TFrom1, TFrom2, TTo>(this (TFrom1, TFrom2) @this, Func<TFrom1, TFrom2, TTo> transformation)
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

        public struct LazyEval<T, TOut>
        {
            private bool evaluated;
            private TOut cache;
            private T inArg;
            private Func<T, TOut> factory;
            public TOut Value => evaluated ? cache : cache.Let(out evaluated, true).Let(out cache, factory(inArg));
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            public LazyEval(Func<T, TOut> factory, T inArg)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                => (this.factory, this.inArg, evaluated, cache) = (factory, inArg, false, default);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            public static implicit operator TOut(LazyEval<T, TOut> lazy)
                => lazy.Value;
        }

        public static T LetLazy<T, TOut>(this T @this, out LazyEval<T, TOut> alias, Func<T, TOut> lambda)
            => @this.Let(out alias, new LazyEval<T, TOut>(lambda, @this));
    }
}
