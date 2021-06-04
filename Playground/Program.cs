using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;

/*
Console.ReadLine()
.Alias(out var input)
.Parse<int>()
.Match(
    valid => $"Valid number! {valid}",
    () => "Oops, invalid!"
)
.Inject(input)
.Map((output, input) => $"Input: {input}\nOutput: {output}")
.Execute(Console.WriteLine);
*/

var input = Console.ReadLine();
string output;
if (int.TryParse(input, out var valid))
    output = $"Valid number! {valid}";
else
    output = "Oops, invalid!";
Console.WriteLine($"Input: {input}\nOutput: {output}");