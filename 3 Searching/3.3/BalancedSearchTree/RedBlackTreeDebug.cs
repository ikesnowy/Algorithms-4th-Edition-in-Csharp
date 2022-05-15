using System;
using System.Collections.Generic;
using System.Text;

namespace BalancedSearchTree;

public class RedBlackTreeDebug<TKey, TValue>  : RedBlackBst<TKey, TValue>
    where TKey : IComparable<TKey>
{
    /// <inheritdoc />
    protected override Node Put(Node h, TKey key, TValue value)
    {
        if (h == null)
        {
            return new Node(key, value, Color.Red, 1);
        }

        var cmp = key.CompareTo(h.Key);
        if (cmp < 0)
        {
            h.Left = Put(h.Left, key, value);
            this.WriteToConsole();
        }
        else if (cmp > 0)
        {
            h.Right = Put(h.Right, key, value);
            this.WriteToConsole();
        }
        else
        {
            h.Value = value;
        }

        if (IsRed(h.Right) && !IsRed(h.Left))
        {
            h = RotateLeft(h);
            Console.WriteLine("Rotate left on {0}", h.Key);
        }

        if (IsRed(h.Left) && IsRed(h.Left.Left))
        {
            h = RotateRight(h);
            Console.WriteLine("Rotate right on {0}", h.Key);
        }

        if (IsRed(h.Left) && IsRed(h.Right))
        {
            FlipColors(h);
            Console.WriteLine("Flip colors on {0}", h.Key);
        }

        h.Size = Size(h.Left) + Size(h.Right) + 1;

        return h;
    }
}