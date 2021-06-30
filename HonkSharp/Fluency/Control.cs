using System;
using System.Diagnostics.CodeAnalysis;
using HonkSharp.Functional;

namespace HonkSharp.Fluency
{
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
#pragma warning disable 1591
    public static class ControlExtensions
#pragma warning restore 1591
    {
        /// <summary>
        /// Performs a transformation from the current
        /// object to a new object with the given mapping
        /// function.
        /// </summary>
        /// <param name="transformation">
        /// Function which transforms the object
        /// (which is passed as the only reference)
        /// and returns something else 
        /// </param>
        /// <typeparam name="TFrom">
        /// The type of the flow end
        /// (current object)
        /// </typeparam>
        /// <typeparam name="TTo">
        /// Arbitrary type to transform to
        /// </typeparam>
        /// <returns>
        /// An instance of TTo
        /// </returns>
#pragma warning disable 1573
        public static TTo Pipe<TFrom, TTo>(this TFrom @this, Func<TFrom, TTo> transformation)
#pragma warning restore 1573
            => transformation(@this);

        /// <summary>
        /// Same as <see cref="Pipe{TFrom, TTo}"/>, but for
        /// 2 sequential transformations
        /// </summary>
        public static T3 Pipe<T1, T2, T3>(this T1 @this, Func<T1, T2> t1, Func<T2, T3> t2)
            => t2(t1(@this));

        /// <summary>
        /// Same as <see cref="Pipe{TFrom, TTo}"/>, but for
        /// 3 sequential transformations
        /// </summary>
        public static T4 Pipe<T1, T2, T3, T4>(this T1 @this, Func<T1, T2> t1, Func<T2, T3> t2, Func<T3, T4> t3)
            => t3(t2(t1(@this)));

        /// <summary>
        /// Performs a transformation from the current
        /// object AND injected object to a new object
        /// with the given mapping function.
        /// </summary>
        /// <param name="transformation">
        /// Function which transforms the object AND
        /// injected object which are passed as two
        /// variables and returns something else 
        /// </param>
        /// <typeparam name="TFrom1">
        /// The type of the flow end
        /// (current object)
        /// </typeparam>
        /// <typeparam name="TFrom2">
        /// The type of the injected object
        /// </typeparam>
        /// <typeparam name="TTo">
        /// Arbitrary type to transform to
        /// </typeparam>
        /// <returns>
        /// An instance of TTo
        /// </returns>
#pragma warning disable 1573
        public static TTo Pipe<TFrom1, TFrom2, TTo>(this (TFrom1 Current, TFrom2 Injected) @this, Func<TFrom1, TFrom2, TTo> transformation)
#pragma warning restore 1573
            => transformation(@this.Item1, @this.Item2);

        /// <summary>
        /// Pipes the given flow into a unit,
        /// performing an operation
        /// (with possibly side-effect or mutations)
        /// </summary>
        public static Unit Pipe<T>(this T @this, Action<T> act)
        {
            act(@this);
            return Unit.Flow;
        }
        
        /// <summary>
        /// Injects an object as a second
        /// element of a tuple generated as a result.
        /// Useful to avoid variable capturing.
        /// </summary>
        public static (TThis Current, TNew Injected) Inject<TThis, TNew>(this TThis @this, TNew @new)
            => (@this, @new);

        /// <summary>
        /// Nullifies the given type in case the condition
        /// is true.
        /// </summary>
        public static TFrom? NullIf<TFrom>(this TFrom @this, Func<TFrom, bool> caseToNullify) where TFrom : struct
            => caseToNullify(@this) ? null : @this;
        
        /// <summary>
        /// Nullifies the given type in case the condition
        /// is true.
        /// </summary>
        public static TFrom? NullIf<TFrom>(this TFrom @this, bool caseToNullify) where TFrom : struct
            => caseToNullify ? null : @this;

        /// <summary>
        /// Assigns the current
        /// flow end to a variable
        /// </summary>
        public static T Alias<T>(this T @this, out T alias)
            => alias = @this;

        /// <summary>
        /// Assigns arbitrary expression to a variable
        /// </summary>
        public static T Let<T, TOut>(this T @this, out TOut alias, TOut value) where TOut : class
            => value
                .Alias(out alias)
                .Inject(@this)
                .Injected;

        /// <summary>
        /// Assigns arbitrary expression to a variable
        /// </summary>
        public static T Let<T, TOut>(this T @this, out TOut alias, in TOut value)
            => value
                .Alias(out alias)
                .Inject(@this)
                .Injected;

        /// <summary>
        /// Assigns arbitrary expression to a variable lazily
        /// </summary>
        public static T LetLazy<T, TOut>(this T @this, out LazyEval<T, TOut> alias, Func<T, TOut> lambda)
            => @this.Let(out alias, new LazyEval<T, TOut>(lambda, @this));
        
        /// <summary>
        /// This type is a lazily-evaluated value
        /// </summary>
        public sealed class LazyEval<T, TOut>
        {
            private bool evaluated;
            private TOut cache;
            private readonly T inArg;
            private readonly Func<T, TOut> factory;
            
            /// <summary>
            /// The value of the type.
            /// Is guaranteed to be evaluated once
            /// for single-threaded use.
            /// </summary>
            public TOut Value => evaluated ? cache : cache.Let(out evaluated, true).Let(out cache, factory(inArg)).ReplaceWith(cache);
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            
            /// <summary>
            /// Creates an instance of the type.
            /// Use LetLazy as syntax for creating it.
            /// </summary>
            public LazyEval(Func<T, TOut> factory, T inArg)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                => (this.factory, this.inArg, evaluated, cache) = (factory, inArg, false, default);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable 1591
            public static implicit operator TOut(LazyEval<T, TOut> lazy)
#pragma warning restore 1591
                => lazy.Value;
        }

        /// <summary>
        /// Replaces the flow end
        /// with the given object
        /// </summary>
        public static TOut ReplaceWith<T, TOut>(this T _, TOut newValue)
            => newValue;
        
        /// <summary>
        /// Replaces the flow end
        /// with the ref of given object by ref
        /// </summary>
        public static ref TOut ReplaceWith<T, TOut>(this T _, ref TOut newValue)
            => ref newValue;

        /// <summary>
        /// Flow end object for exception-prone code
        /// </summary>
        public readonly struct DangerousCode<T>
        {
            private readonly T tin;
            
            /// <summary>
            /// Starts a block of "dangerous",
            /// exception-prone code.
            /// </summary>
            public DangerousCode(T tin) => this.tin = tin; 
            
            /// <summary>
            /// Tries executing code or returns failure of the exception
            /// </summary>
            public Either<TOut, Failure<TException>> Try<TException, TOut>(Func<T, TOut> dangerousCode)
                where TException : Exception
            {
                try
                {
                    return dangerousCode(tin);
                }
                catch (TException e)
                {
                    return new Failure<TException>(e);
                }
            }
        }

        
        /// <summary>
        /// Starts an exception-prone block
        /// </summary>
        public static DangerousCode<T> Dangerous<T>(this T @this)
            => new DangerousCode<T>(@this);

        /// <summary>
        /// Unconditionally throws an exception
        /// </summary>
        public static Unit Throw<T>(this T @this, Exception exception)
            => throw exception;

        /// <summary>
        /// Discards the current flow end
        /// </summary>
        public static Unit Discard<T>(this T @this)
            => new();
    }
}
