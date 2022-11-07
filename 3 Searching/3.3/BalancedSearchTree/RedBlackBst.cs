using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

// ReSharper disable CognitiveComplexity

namespace BalancedSearchTree;

public class RedBlackBst<TKey, TValue> : IOrderedSt<TKey, TValue>
    where TKey : IComparable<TKey>
{
    private Node? _root;

    public RedBlackBst()
    {
    }

    public RedBlackBst(Node root)
    {
        _root = root;
    }

    /// <inheritdoc />
    public void Put(TKey key, TValue value)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key), "first argument to put() is null");
        }

        if (value == null)
        {
            Delete(key);
            return;
        }

        _root = Put(_root, key, value);
        _root.Color = Color.Black;
    }

    protected virtual Node Put(Node? h, TKey key, TValue value)
    {
        if (h == null)
        {
            return new Node(key, value, Color.Red, 1);
        }

        var cmp = key.CompareTo(h.Key);
        if (cmp < 0)
        {
            h.Left = Put(h.Left, key, value);
        }
        else if (cmp > 0)
        {
            h.Right = Put(h.Right, key, value);
        }
        else
        {
            h.Value = value;
        }

        if (IsRed(h.Right) && !IsRed(h.Left))
        {
            h = RotateLeft(h);
        }

        if (IsRed(h.Left) && IsRed(h.Left!.Left))
        {
            h = RotateRight(h);
        }

        if (IsRed(h.Left) && IsRed(h.Right))
        {
            FlipColors(h);
        }

        h.Size = Size(h.Left) + Size(h.Right) + 1;

        return h;
    }

    /// <inheritdoc />
    public TValue? Get(TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key), "key should not be null");
        }

        return Get(_root, key);
    }

    protected TValue? Get(Node? x, TKey key)
    {
        while (x != null)
        {
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
            {
                x = x.Left;
            }
            else if (cmp > 0)
            {
                x = x.Right;
            }
            else
            {
                return x.Value;
            }
        }

        return default;
    }

    /// <inheritdoc />
    public void Delete(TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key), "argument to Delete() is null");
        }

        if (IsEmpty())
        {
            throw new InvalidOperationException("Red Black Tree Underflow");
        }

        if (!IsRed(_root.Left) && !IsRed(_root.Right))
        {
            _root.Color = Color.Red;
        }

        _root = Delete(_root, key);
        if (!IsEmpty())
        {
            _root.Color = Color.Black;
        }
    }

    protected Node? Delete(Node? h, TKey key)
    {
        if (h == null)
        {
            return null;
        }
        
        if (key.CompareTo(h.Key) < 0)
        {
            if (!IsRed(h.Left) && !IsRed(h.Left!.Left))
            {
                h = MoveRedRight(h);
            }

            h.Left = Delete(h.Left, key);
        }
        else
        {
            if (IsRed(h.Left))
            {
                h = RotateRight(h);
            }

            if (key.CompareTo(h.Key) == 0 && (h.Right == null))
            {
                return null;
            }

            if (!IsRed(h.Right) && !IsRed(h.Right!.Left))
            {
                h = MoveRedRight(h);
            }

            if (key.CompareTo(h.Key) == 0)
            {
                var x = Min(h.Right!);
                h.Key = x.Key;
                h.Value = x.Value;
                h.Right = DeleteMin(h);
            }
            else
            {
                h.Right = Delete(h.Right, key);
            }
        }

        return Balance(h);
    }

    /// <inheritdoc />
    public bool Contains(TKey key)
    {
        return Get(_root, key) != null;
    }

    /// <inheritdoc />
    [MemberNotNullWhen(false, nameof(_root))]
    public bool IsEmpty()
    {
        return _root == null;
    }

    /// <inheritdoc />
    public int Size()
    {
        return Size(_root);
    }

    /// <inheritdoc />
    public int Size(TKey lo, TKey hi)
    {
        if (lo == null)
        {
            throw new ArgumentNullException(nameof(lo), "first argument to Size() is null");
        }

        if (hi == null)
        {
            throw new ArgumentNullException(nameof(hi), "second argument to Size() is null");
        }

        if (lo.CompareTo(hi) > 0)
        {
            return 0;
        }

        if (Contains(hi))
        {
            return Rank(hi) - Rank(lo) + 1;
        }

        return Rank(hi) - Rank(lo);
    }

    /// <inheritdoc />
    public IEnumerable<TKey> Keys()
    {
        if (IsEmpty())
        {
            return new List<TKey>();
        }

        return Keys(Min(), Max());
    }

    /// <inheritdoc />
    public IEnumerable<TKey> Keys(TKey lo, TKey hi)
    {
        if (lo == null)
        {
            throw new ArgumentNullException(nameof(lo), "first argument to Keys() is null");
        }

        if (hi == null)
        {
            throw new ArgumentNullException(nameof(hi), "second argument to Keys() is null");
        }

        var queue = new Queue<TKey>();
        Keys(_root, queue, lo, hi);
        return queue;
    }

    protected void Keys(Node? x, Queue<TKey> queue, TKey lo, TKey hi)
    {
        if (x == null)
        {
            return;
        }

        var cmpLo = lo.CompareTo(x.Key);
        var cmpHi = hi.CompareTo(x.Key);
        if (cmpLo < 0)
        {
            Keys(x.Left, queue, lo, hi);
        }

        if (cmpLo <= 0 && cmpHi >= 0)
        {
            queue.Enqueue(x.Key);
        }

        if (cmpHi > 0)
        {
            Keys(x.Right, queue, lo, hi);
        }
    }

    /// <inheritdoc />
    public TKey Min()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("calls min() with empty symbol table");
        }

        return Min(_root).Key;
    }

    protected Node Min(Node x)
    {
        if (x.Left == null)
        {
            return x;
        }

        return Min(x.Left);
    }

    /// <inheritdoc />
    public TKey Max()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("calls Max() with empty symbol table");
        }

        return Max(_root).Key;
    }

    protected Node Max(Node x)
    {
        if (x.Right == null)
        {
            return x;
        }

        return Max(x.Right);
    }

    /// <inheritdoc />
    public TKey Floor(TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key), "argument to Floor() is null");
        }

        if (IsEmpty())
        {
            throw new InvalidOperationException("calls Floor() with empty symbol table");
        }

        var x = Floor(_root, key);
        if (x == null)
        {
            throw new InvalidOperationException("argument to Floor() is too small");
        }

        return x.Key;
    }

    protected Node? Floor(Node? x, TKey key)
    {
        if (x == null)
        {
            return null;
        }

        var cmp = key.CompareTo(x.Key);
        if (cmp == 0)
        {
            return x;
        }

        if (cmp < 0)
        {
            return Floor(x.Left, key);
        }

        var t = Floor(x.Right, key);
        if (t != null)
        {
            return t;
        }

        return x;
    }

    /// <inheritdoc />
    public TKey Ceiling(TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key), "argument to Ceiling() is null");
        }

        if (IsEmpty())
        {
            throw new InvalidOperationException("calls Ceiling with empty symbol table");
        }

        var x = Ceiling(_root, key);
        if (x == null)
        {
            throw new InvalidOperationException("argument to Ceiling is too small");
        }

        return x.Key;
    }

    protected Node? Ceiling(Node? x, TKey key)
    {
        if (x == null)
        {
            return null;
        }

        var cmp = key.CompareTo(x.Key);
        if (cmp == 0)
        {
            return x;
        }

        if (cmp > 0)
        {
            return Ceiling(x.Right, key);
        }

        var t = Ceiling(x.Left, key);
        if (t != null)
        {
            return t;
        }

        return x;
    }

    /// <inheritdoc />
    public int Rank(TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key), "argument to Rank() is null");
        }

        return Rank(_root, key);
    }

    protected int Rank(Node? x, TKey key)
    {
        if (x == null)
        {
            return 0;
        }

        var cmp = key.CompareTo(x.Key);
        if (cmp < 0)
        {
            return Rank(x.Left, key);
        }

        if (cmp > 0)
        {
            return 1 + Size(x.Left) +  Rank(x.Right, key);
        }
        return Size(x.Left);
    }

    /// <inheritdoc />
    public TKey? Select(int k)
    {
        if (k < 0 || k >= Size())
        {
            throw new ArgumentOutOfRangeException(nameof(k), "argument to Select() is invalid " + k);
        }

        return Select(_root, k);
    }

    protected TKey? Select(Node? x, int rank)
    {
        if (x == null)
        {
            return default;
        }

        var leftSize = Size(x.Left);
        if (leftSize > rank)
        {
            return Select(x.Left, rank);
        }

        if (leftSize < rank)
        {
            return Select(x.Right, rank - leftSize - 1);
        }
        return x.Key;
    }

    /// <inheritdoc />
    public void DeleteMin()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("BST underflow");
        }

        if (!IsRed(_root.Left) && !IsRed(_root.Right))
        {
            _root.Color = Color.Red;
        }

        _root = DeleteMin(_root);
        if (!IsEmpty())
        {
            _root.Color = Color.Black;
        }
    }

    protected Node? DeleteMin(Node h)
    {
        if (h.Left == null)
        {
            return null;
        }

        if (!IsRed(h.Left) && !IsRed(h.Left.Left))
        {
            h = MoveRedLeft(h);
        }

        h.Left = DeleteMin(h.Left!);
        return Balance(h);
    }

    /// <inheritdoc />
    public void DeleteMax()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("BST underflow");
        }

        if (!IsRed(_root.Left) && !IsRed(_root.Right))
        {
            _root.Color = Color.Red;
        }

        _root = DeleteMax(_root);
        if (!IsEmpty())
        {
            _root.Color = Color.Black;
        }
    }
    
    /// <summary>
    /// 获取二叉树的最大深度。
    /// </summary>
    /// <param name="x">二叉树的根结点。</param>
    /// <returns>二叉树的最大深度。</returns>
    protected int Depth(Node? x)
    {
        if (x == null)
            return 0;
        return 1 + Math.Max(Depth(x.Left), Depth(x.Right));
    }
    
    /// <summary>
    /// 将二叉树按照树形输出。
    /// </summary>
    /// <returns>二叉查找树输出的字符串。</returns>
    public override string ToString()
    {
        if (IsEmpty())
            return string.Empty;

        var maxDepth = Depth(_root);
        int layer = 0, bottomLine = (int)Math.Pow(2, maxDepth) * 2;

        // BFS
        var lines = new List<string>();
        var nowLayer = new Queue<Node?>();
        var nextLayer = new Queue<Node?>();
        nextLayer.Enqueue(_root);

        while (layer != maxDepth)
        {
            var sb = new StringBuilder();
            var unitSize = bottomLine / (int)Math.Pow(2, layer);
            var temp = nowLayer;
            nowLayer = nextLayer;
            nextLayer = temp;

            while (nowLayer.Count != 0)
            {
                var x = nowLayer.Dequeue();

                if (x != null)
                {
                    nextLayer.Enqueue(x.Left);
                    nextLayer.Enqueue(x.Right);
                }
                else
                {
                    nextLayer.Enqueue(null);
                    nextLayer.Enqueue(null);
                }

                if (x != null && x.Left != null)
                {
                    for (var i = 0; i < unitSize / 4; i++)
                        sb.Append(' ');
                    sb.Append(IsRed(x.Left) ? "||" : "|");
                    for (var i = 1; i < unitSize / 4; i++)
                        sb.Append('-');
                }
                else
                {
                    for (var i = 0; i < unitSize / 2; i++)
                        sb.Append(' ');
                }

                if (x == null)
                    sb.Append(' ');
                else
                    sb.Append(x.Key);

                if (x != null && x.Right != null)
                {
                    for (var i = 1; i < unitSize / 4; i++)
                        sb.Append('-');
                    sb.Append(IsRed(x.Right) ? "||" : '|');
                    for (var i = 1; i < unitSize / 4; i++)
                        sb.Append(' ');
                }
                else
                {
                    for (var i = 1; i < unitSize / 2; i++)
                        sb.Append(' ');
                }
            }
            lines.Add(sb.ToString());
            layer++;
        }

        // Trim
        var margin = int.MaxValue;
        foreach (var line in lines)
        {
            var firstNonWhite = 0;
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ') continue;
                firstNonWhite = i;
                break;
            }

            margin = Math.Min(margin, firstNonWhite);
        }

        for (var i = 0; i < lines.Count; i++)
        {
            lines[i] = lines[i].Substring(margin);
        }

        var result = new StringBuilder();
        foreach (var line in lines)
        {
            result.AppendLine(line);
        }

        return result.ToString();
    }

    protected Node? DeleteMax(Node h)
    {
        if (IsRed(h.Left))
        {
            h = RotateRight(h);
        }

        if (h.Right == null)
        {
            return null;
        }

        if (!IsRed(h.Right) && !IsRed(h.Right.Left))
        {
            h = MoveRedRight(h);
        }

        h.Right = DeleteMax(h.Right!);

        return Balance(h);
    }
    
    protected static bool IsRed([NotNullWhen(true)] Node? x)
    {
        if (x == null)
        {
            return false;
        }

        return x.Color == Color.Red;
    }

    protected static int Size(Node? x)
    {
        if (x == null)
        {
            return 0;
        }
            
        return x.Size;
    }

    protected virtual Node RotateRight(Node? h)
    {
        if (h == null || IsRed(h.Left) == false)
        {
            throw new ArgumentException("invalid node for rotating right");
        }

        var x = h.Left;
        h.Left = x.Right;
        x.Right = h;
        x.Color = x.Right.Color;
        x.Right.Color = Color.Red;
        x.Size = h.Size;
        h.Size = Size(h.Left) + Size(h.Right) + 1;
        return x;
    }

    protected virtual Node RotateLeft(Node? h)
    {
        if (h == null || IsRed(h.Right) == false)
        {
            throw new ArgumentException("invalid node for rotating left");
        }

        var x = h.Right;
        h.Right = x.Left;
        x.Left = h;
        x.Color = x.Left.Color;
        x.Left.Color = Color.Red;
        x.Size = h.Size;
        h.Size = Size(h.Left) + Size(h.Right) + 1;
        return x;
    }

    protected virtual void FlipColors(Node h)
    {
        h.Color = Flip(h.Color);
        h.Left!.Color = Flip(h.Left.Color);
        h.Right!.Color = Flip(h.Right.Color);
    }

    protected Node MoveRedLeft(Node h)
    {
        FlipColors(h);
        if (IsRed(h.Right!.Left))
        {
            h.Right = RotateRight(h.Right);
            h = RotateLeft(h);
            FlipColors(h);
        }

        return h;
    }

    protected Node MoveRedRight(Node h)
    {
        FlipColors(h);
        if (IsRed(h.Left!.Left))
        {
            h = RotateRight(h);
            FlipColors(h);
        }

        return h;
    }

    protected Node Balance(Node h)
    {
        if (IsRed(h.Right) && !IsRed(h.Left))
        {
            h = RotateLeft(h);
        }

        if (IsRed(h.Left) && IsRed(h.Left.Left))
        {
            h = RotateRight(h);
        }

        if (IsRed(h.Left) && IsRed(h.Right))
        {
            FlipColors(h);
        }
            
        h.Size = Size(h.Left) + Size(h.Right) + 1;
        return h;
    }

    protected Color Flip(Color color)
    {
        return color == Color.Red ? Color.Black : Color.Red;
    }

    public class Node
    {
        public Node(TKey key, TValue value, Color color, int size)
        {
            Key = key;
            Value = value;
            Color = color;
            Size = size;
        }

        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public Color Color { get; set; }
        public int Size { get; set; }
    }

    public enum Color : byte
    {
        Black = 0,
        Red = 1,
    }
}