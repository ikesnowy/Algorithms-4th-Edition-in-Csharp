using BalancedSearchTree;
using Node = BalancedSearchTree.RedBlackBst<char, int>.Node;
using Color = BalancedSearchTree.RedBlackBst<char, int>.Color;

// 构造题中的红黑树
var root = new Node('j', 1, Color.Black, 21)
{
    Right = new Node('u', 1, Color.Black, 19)
    {
        Left = new Node('t', 1, Color.Red, 17)
        {
            Left = new Node('s', 1, Color.Black, 15)
            {
                Left = new Node('r', 1, Color.Red, 13)
                {
                    Left = new Node('q', 1, Color.Black, 10)
                    {
                        Left = new Node('p', 1, Color.Red, 10)
                        {
                            Left = new Node('l', 1, Color.Black, 8)
                            {
                                Left = new Node('k', 1, Color.Red, 2),
                                Right = new Node('o', 1, Color.Black, 4)
                                {
                                    Left = new Node('m', 1, Color.Red, 0),
                                }
                            },
                        },
                    },
                },
            },
        },
    }
};

var bst = new RedBlackBst<char, int>(root);
bst.Put('n', 1);
Console.WriteLine(bst);