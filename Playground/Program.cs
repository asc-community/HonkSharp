using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;

Console.ReadLine()
    .Dangerous()
    .Try<FormatException, int>(int.Parse)
    .Switch(
        e => $"Exception occured! {e}",
        i => $"Valid integer! {i}"
    )
    .Execute(Console.WriteLine);