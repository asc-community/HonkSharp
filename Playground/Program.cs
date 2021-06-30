using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using HonkSharp.Fluency;
using HonkSharp.Functional;
using System.Linq;


5.3.Pipe(
    a => a.ToString(), 
    a => a.Split("."), 
    a => a[0]
).Pipe(Console.WriteLine);


/*
Console.ReadLine()
    .AssumeBest()
    .Parse<int>()
    .Switch(
        valid => $"Yay, valid int! {valid}",
        _ => "Meh :("
        )
    .Pipe(Console.WriteLine);*/