using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;

5
.Execute(Console.WriteLine)
.LetLazy(out var anotherNumber, _ => Console.ReadLine())
.Inject(anotherNumber)
.Pipe((a, num) => a switch
{
    > 0 => num.Value.Parse<int>().AssumeBest() * 2 + num.Value.ToString(),
    _ => "43"
})
.Execute(Console.WriteLine);

/*Console.ReadLine().Alias(out var input)
.Parse<int>()
.Match(valid => $"Valid number! {valid}",
       () => "Oops, invalid!")
.Inject(input)
.Pipe((output, input) => $"Input: {input}\nOutput: {output}")
.Execute(Console.WriteLine)
.Execute(Console.WriteLine)
.Pipe(a => a + "FJDSKFJKSLDF")
.Execute(Console.WriteLine);
*/

/*
var input = Console.ReadLine();
string output;
if (int.TryParse(input, out var valid))
    output = $"Valid number! {valid}";
else
    output = "Oops, invalid!";
Console.WriteLine($"Input: {input}\nOutput: {output}");
*/
