using System;

namespace BalancedSearchTree;

public static class RedBlockTreeConsoleOutPut
{
    public static void WriteToConsole<TKey, TValue>(this RedBlackBst<TKey, TValue> tree)
        where TKey : IComparable<TKey>
    {
        var treeString = tree.ToString().Split("||");
        for (var i = 0; i < treeString.Length; i++)
        {
            if (i == 0)
            {
                Console.Write(treeString[i]);
                continue;
            }

            var bak = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("|");
            Console.ForegroundColor = bak;
            Console.Write(treeString[i]);
        }
        Console.WriteLine();
    }
}