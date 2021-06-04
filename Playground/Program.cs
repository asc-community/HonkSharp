using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;

IList<int> il = new List<int> { 4 };

Console.WriteLine(
    5
    .Apply(a => a + 6)
    .Apply(a => a * 2)
    .Join(6)
    .Apply((a, b) => a + b)
    .NullIf(a => a < 0)
    ?.Apply(a => Math.Sqrt(a))
);
