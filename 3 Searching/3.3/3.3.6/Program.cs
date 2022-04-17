using System;
using System.Collections.Generic;
using BalancedSearchTree;

// 参见 /docs/content/3-3-6.md 

// N=6，简记为 [{3}, {2, 2, 3}]
var n6 = GetN6();
Console.WriteLine("N=6");
Console.WriteLine(n6);

// N=7
// [{3}, {2, 3, 3}]（插入到某个 2-结点） 或 [{2}, {2, 2}, {2, 2, 2, 2}]（插入到 3-结点，变成满二叉树）
Console.WriteLine("N=7");
var n71 = GetN7('L');
Console.WriteLine("7-1, p = 4/7");
Console.WriteLine(n71);
var n72 = GetN7('Q');
Console.WriteLine("7-2, p = 3/7");
Console.WriteLine(n72);

// N=8
// [{3}, {3, 3, 3}]（插入到唯一的 2-结点），[{2}, {2, 2}, {2, 2, 2, 3}]（插入到满二叉树底部任意一个 2-结点）
// 注：向 [{3}, {2, 3, 3}] 的 3-结点插入元素变换后的树形等同于向满二叉树插入一个新元素 
Console.WriteLine("N=8");
var n81 = GetN8('L', 'A');
Console.WriteLine("8-1, p = 1/7");
Console.WriteLine(n81);

var n82 = GetN8('Q', 'Z');
Console.WriteLine("8-2, p = 6/7");
Console.WriteLine(n82);

// N=9
// [{2}, {2, 3}, {2, 2, 2, 2, 2}]（插入到 3-结点）, [{2}, {2, 2}, {2, 2, 3, 3}]（插入到同侧 2-结点）, [{2}, {2, 2}, {2, 3, 2, 3}]（插入到对侧 2-结点）
Console.WriteLine("N=9");
var n91 = GetN9('L', 'A', 'C');
Console.WriteLine("9-1, p = 2/7");
Console.WriteLine(n91);

var n92 = GetN9('Q', 'Z', 'X');
Console.WriteLine("9-2, p = 3/7");
Console.WriteLine(n92);

var n93 = GetN9('L', 'A', 'J');
Console.WriteLine("9-3, p = 2/7");
Console.WriteLine(n93);

// N=10
// [{2}, {2, 2}, {2, 3, 3, 3}]（插入到 2-结点）, [{2}, {2, 3}, {2, 2, 2, 2, 3}]（插入到 3-结点下的 2-结点）, [{2}, {2, 3}, {2, 3, 2, 2, 2}]（插入到 2-结点下的 2-结点）
Console.WriteLine("N=10");
var n101 = GetN10('L', 'A', 'C', 'B');
Console.WriteLine("10-1, p = 2/7");
Console.WriteLine(n101);

var n102 = GetN10('Q', 'Z', 'X', 'P');
Console.WriteLine("10-2, p = 12/35");
Console.WriteLine(n102);

var n103 = GetN10('Q', 'Z', 'X', 'J');
Console.WriteLine("10-3, p = 13/35");
Console.WriteLine(n103);

TwoThreeBst<char, char> GetN6()
{
    var tree = new TwoThreeBst<char, char>();
    new List<char>{'D', 'G', 'K', 'O', 'S', 'Y'}.ForEach(x => tree.Put(x, x));
    return tree;
}

TwoThreeBst<char, char> GetN7(char key)
{
    var tree = GetN6();
    tree.Put(key, key);
    return tree;
}

TwoThreeBst<char, char> GetN8(char key1, char key2)
{
    var tree = GetN7(key1);
    tree.Put(key2, key2);
    return tree;
}

TwoThreeBst<char, char> GetN9(char key1, char key2, char key3)
{
    var tree = GetN8(key1, key2);
    tree.Put(key3, key3);
    return tree; 
}

TwoThreeBst<char, char> GetN10(char key1, char key2, char key3, char key4)
{
    var tree = GetN9(key1, key2, key3);
    tree.Put(key4, key4);
    return tree;
}