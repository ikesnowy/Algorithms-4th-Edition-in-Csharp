using BalancedSearchTree;
using System;

var tree = new TwoThreeBst<char, int>();
var input = "YLPMXHCRAES";
foreach (var c in input)
{
    tree.Put(c, 1);
    Console.WriteLine(tree.ToString());
}
