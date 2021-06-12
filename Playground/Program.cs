using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;

var a = new Either<int, string>(5);

a.As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .As<int>().As<int>().As<int>().As<int>().As<int>()
    .AssumeBest().Pipe(Console.WriteLine);