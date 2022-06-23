﻿using BalancedSearchTree;

const string input = "EASYQUESTION";
var tree = new RedBlackBst<char, int>();
foreach (var c in input)
{
    tree.Put(c, 0);
    tree.WriteToConsole();
}