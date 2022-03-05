using System;
using System.IO;
using Measurement;
using TestCase;

var split = new[] { '\n' };
var input = File.ReadAllText(DataFiles._2KInts).Split(split, StringSplitOptions.RemoveEmptyEntries);
var a = new int[input.Length];
for (var i = 0; i < input.Length; i++)
{
    a[i] = int.Parse(input[i]);
}

var array = new StaticSeTofInts(a);
Console.WriteLine(array.Contains(10000000)); //False
Console.WriteLine(array.Contains(-174307)); //True