using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;

(..)
.AsRange()
.AssumeBest()
.ExecuteForAll(_ => 
    Console.ReadLine()
    .LetLazy(out var big, a => "Okay, write the next letter"
                                    .Execute(Console.WriteLine)
                                    .ReplaceWith(Console.ReadLine())
                                    .Parse<int>()
                                    .AssumeBest())
    .Parse<int>()
    .AssumeBest()
    .Inject(big)
    .Map((a, big) => a switch
    {
        > 12 => a + big,
        > 6 and < 10 => big * 2,
        _ => 6
    })
    .Execute(Console.WriteLine)
);
