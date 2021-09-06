using System;
using System.IO;
using BalancedSearchTree;

var input = "ACEHMSX";
var output = File.CreateText("result.txt");
var count = 0;
Dig(input, string.Empty);
Console.WriteLine(count);

void Dig(string source, string testCase)
{
    if (source.Length == 0)
    {
        var tree = new TwoThreeBst<char, int>();
        foreach (var c in testCase)
        {
            tree.Put(c, 1);
        }

        if (tree.Height() == 1)
        {
            count++;
            output.WriteLine(testCase);
            output.WriteLine(tree.ToString());
            output.WriteLine();
        } 
    }
    
    for (var i = 0; i < source.Length; i++)
    {
        Dig(source.Remove(i, 1), testCase + source[i]);
    }
}