using System;
using BalancedSearchTree;

var tree = new TwoThreeBst<char, int>();
var input = "EASYQUTION";
foreach (var c in input)
{
    tree.Put(c, 1);
    Console.WriteLine(tree.ToString());
}