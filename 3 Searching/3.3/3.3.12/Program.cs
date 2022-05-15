using BalancedSearchTree;

const string input = "SEARCHEXAMPLE";
var tree = new RedBlackTreeDebug<char, int>();
foreach (var c in input)
{
    Console.WriteLine("Inserting " + c);
    tree.Put(c, 0);
    tree.WriteToConsole();
}