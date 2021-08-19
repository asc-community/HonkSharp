using System;

namespace HonkSharp.Functional
{
    public static class Currying
    {
        public static Func<T2, TOut> Y<T1, T2, TOut>(this Func<T1, T2, TOut> f, T1 arg)
            => t2 => f(arg, t2);
    }
}