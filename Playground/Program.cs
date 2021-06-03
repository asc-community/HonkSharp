using System;
using DeclarativeCSharp.Functional;

// it doesn't work :(((

var u = new EitherU4<int, bool, uint, ushort>(4u);
Console.WriteLine(
    u.Switch(
        i => "it's int",
        b => "it's bool",
        ui => "it's uint",
        us => "it's short"
    )
);
