using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;

A a = new B();

Console.Write(a.Downcast<B>());

class A {}

class B : A{}

