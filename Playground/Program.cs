using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;


Console.ReadLine()
    .Dangerous()
    .Try<FormatException, int>(int.Parse)
    .Switch(
        result => $"Valid integer! {result}",
        fail => $"Exception occured! {fail.Reason.Message}"
    )
    .Execute(Console.WriteLine);