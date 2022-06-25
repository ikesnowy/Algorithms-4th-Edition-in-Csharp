using BalancedSearchTree;

// 具体证明见上一题的解答。
var bst = new RedBlackBst<string, int>();
var input = "A B C D E F G H I J K".Split(' ');
foreach (var s in input)
{
    bst.Put(s, 1);
    Console.WriteLine(bst);
}