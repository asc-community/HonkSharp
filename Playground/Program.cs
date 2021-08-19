using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using HonkSharp.Fluency;
using HonkSharp.Functional;
using System.Linq;


var l = LList.Of(new [] { 1, 2, 3, 4, 5, 6 });
Console.WriteLine(l);
Console.WriteLine(Reverse(l));
Console.WriteLine(10 + Reverse(l));
Console.WriteLine(l == LList.Of(new [] { 1, 2, 3, 4, 5 }));
Console.WriteLine(l == LList.Of(new [] { 1, 2, 3 }));
Console.WriteLine(Quack(l));
Console.WriteLine(Quack(l.Map(el => el * 3)));
Console.WriteLine(l.Where(c => c > 3).Map(c => c / 3));



static int Sum(LList<int>? ints)
    => ints switch
    {
        null => 0,
        (var head, var tail) => head + Sum(tail)
    };

static LList<int>? Reverse(LList<int>? ints, LList<int>? inner = null)
    => ints switch
    {
        null => inner,
        (var head, var tail) => Reverse(tail, head + inner)
    };

static LList<(int, int)>? Quack(LList<int>? ints)
    => ints switch
    {
        null => null,
        (var h1, (var h2, var tail)) => (h1, h2) + Quack(tail),
        _ => throw new ArgumentException(nameof(ints)),
    };