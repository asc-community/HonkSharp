using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using HonkSharp.Fluency;
using HonkSharp.Functional;


Console.ReadLine()
    .AssumeBest()
    .Parse<int>()
    .Switch(
        valid => $"Yay, valid int! {valid}",
        _ => "Meh :("
        )
    .Pipe(Console.WriteLine);