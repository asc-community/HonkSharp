using HonkSharp.Fluency;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HonkSharp.Functional
{
    public static class Recursors
    {
        public static Func<TIn, TOut> prec<TIn, TOut>(Func<TIn, Func<TIn, TOut>, TOut> recInfo)
        {
            TOut Inner(TIn arg)
            {
                return recInfo(arg, i => Inner(i));
            }
            return Inner;
        }
        
        public static Func<TIn, TOut> mrec<TIn, TOut>(Func<TIn, Func<TIn, TOut>, TOut> recInfo)
        {
            var dict = new Dictionary<TIn, TOut>();
            TOut Inner(TIn arg)
            {
                if (dict.TryGetValue(arg, out var res))
                    return res;
                res = recInfo(arg, i => Inner(i));
                dict[arg] = res;
                return res;
            }
            return Inner;
        }
    }
}