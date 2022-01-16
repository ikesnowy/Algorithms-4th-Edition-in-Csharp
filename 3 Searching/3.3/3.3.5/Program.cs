using BalancedSearchTree;

// N=6，简记为 [{3}, {2, 2, 3}]
var n6 = GetN6();
Console.WriteLine("N=6");
Console.WriteLine(n6);

// 注，英文版原文是 ignore the order of the subtrees，也就是忽略子树的顺序，只统计每层两种结点的不同数量组合

// N=7
// [{3}, {2, 3, 3}]（插入到某个 2-结点） 或 [{2}, {2, 2}, {2, 2, 2, 2}]（插入到 3-结点，变成满二叉树）
Console.WriteLine("N=7");
var n71 = GetN6();
n71.Put('L', 'L');
Console.WriteLine(n71);
var n72 = GetN6();
n72.Put('Q', 'Q');
Console.WriteLine(n72);

// N=8
// [{3}, {3, 3, 3}]（插入到唯一的 2-结点），[{2}, {2, 2}, {2, 2, 2, 3}]（插入到满二叉树底部任意一个 2-结点）
// 注：向 [{3}, {2, 3, 3}] 的 3-结点插入元素变换后的树形等同于向满二叉树插入一个新元素 
Console.WriteLine("N=8");
var n81 = n71;
n81.Put('A', 'A');
Console.WriteLine(n81);

var n82 = n72;
n82.Put('Z', 'Z');
Console.WriteLine(n82);

// N=9
//  [{2}, {2, 3}, {2, 2, 2, 2, 2}], [{2}, {2, 2}, {2, 2, 3, 3}]
Console.WriteLine("N=9");
var n91 = n81;
n91.Put('C', 'C');
Console.WriteLine(n91);

var n92 = n82;
n92.Put('X', 'X');
Console.WriteLine(n92);

// N=10
// [{2}, {2, 2}, {2, 3, 3, 3}], [{2}, {2, 3}, {2, 2, 2, 2, 3}]
Console.WriteLine("N=10");
var n101 = n91;
n101.Put('B', 'B');
Console.WriteLine(n101);

var n102 = n92;
n102.Put('P', 'P');
Console.WriteLine(n102);


TwoThreeBst<char, char> GetN6()
{
    var tree = new TwoThreeBst<char, char>();
    new List<char>{'D', 'G', 'K', 'O', 'S', 'Y'}.ForEach(x => tree.Put(x, x));
    return tree;
}