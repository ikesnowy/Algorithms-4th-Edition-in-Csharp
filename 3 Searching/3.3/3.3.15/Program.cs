using BalancedSearchTree;

// 具体证明见 3.3.13 的解答，倒序插入无法保证高度递增。
var bst = new RedBlackBst<string, int>();
var input = "A B C D E F G H I J K".Split(' ').Reverse();
foreach (var s in input)
{
    bst.Put(s, 1);
    Console.WriteLine(bst);
}