using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;

(1, 15)
.AsRange()
.ExecuteForAll(_ => 
    Console.ReadLine()
    .Parse<byte>()
    .Match(
        b => $"Success! {b}",
        () => "Nope :("
    )
    .Execute(Console.WriteLine)
);