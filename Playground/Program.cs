using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using HonkSharp.Fluency;
using HonkSharp.Functional;
using System.Linq;

(3..)
    .Where(a => a % 2 is 0)
    .Select(a => a * a)
    .TakeWhile(a => a < 1000)
    .Pipe(", ".Join)
    .Pipe(Console.WriteLine);


Console.ReadLine();
/*
Console.ReadLine()
    .AssumeBest()
    .Parse<int>()
    .Switch(
        valid => $"Yay, valid int! {valid}",
        _ => "Meh :("
        )
    .Pipe(Console.WriteLine);*/