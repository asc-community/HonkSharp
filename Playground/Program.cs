using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;


5
.LetLazy(out var big, a => a + 3 + (int)Math.Sqrt(a))
.Inject(big)
.Map((a, big) => a switch
{
    > 12 => a + big,
    > 6 and < 10 => big * 2,
    _ => 6
})
.Execute(Console.WriteLine);
