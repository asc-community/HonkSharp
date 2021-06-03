using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;

IList<int> il = new List<int> { 4 };

il.Downcast<IList<int>, List<int>>()[0] = 5;
