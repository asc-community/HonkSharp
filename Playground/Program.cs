using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using HonkSharp.Fluency;
using HonkSharp.Functional;
using System.Linq;


"333".Parse<int>().Pipe(c => Console.WriteLine(c));

"3ddd".Parse<int>().Pipe(c => Console.WriteLine(c));

((string?)null).Dangerous().Try<Exception, string>(s => s!.ToString()).Pipe(c => Console.WriteLine(c));








/*
Console.ReadLine()
    .AssumeBest()
    .Parse<int>()
    .Switch(
        valid => $"Yay, valid int! {valid}",
        _ => "Meh :("
        )
    .Pipe(Console.WriteLine);*/