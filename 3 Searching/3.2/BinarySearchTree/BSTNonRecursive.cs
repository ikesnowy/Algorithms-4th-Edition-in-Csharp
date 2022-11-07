﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
// ReSharper disable CognitiveComplexity

namespace BinarySearchTree;

/// <summary>
/// 非递归的二叉树实现。
/// </summary>
/// <typeparam name="TKey">键类型。</typeparam>
/// <typeparam name="TValue">值类型。</typeparam>
public class BstNonRecursive<TKey, TValue> : ISt<TKey, TValue>, IOrderedSt<TKey, TValue>
    where TKey : IComparable<TKey>
{
    /// <summary>
    /// 二叉查找树的根结点。
    /// </summary>
    private Node? _root;

    /// <summary>
    /// 二叉树结点类型。
    /// </summary>
    private class Node
    {
        /// <summary>
        /// 键值对中的键。
        /// </summary>
        /// <value>
        /// 键。
        /// </value>
        public TKey? Key { get; set; }
        /// <summary>
        /// 键值对中的值。
        /// </summary>
        /// <value>值。</value>
        public TValue? Value { get; set; }
        /// <summary>
        /// 左子树的引用。
        /// </summary>
        /// <value>左子树的引用。</value>
        public Node? Left { get; set; }
        /// <summary>
        /// 右子树的引用。
        /// </summary>
        /// <value>右子树的引用。</value>
        public Node? Right { get; set; }
        /// <summary>
        /// 子树的结点数量。
        /// </summary>
        /// <value>子树的结点数量。</value>
        public int Size { get; set; }

        /// <summary>
        /// 构造一个二叉树结点。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        /// <param name="size">子树大小。</param>
        public Node(TKey key, TValue? value, int size)
        {
            Key = key;
            Value = value;
            Size = size;
            Left = null;
            Right = null;
        }
    }

    /// <summary>
    /// 向二叉查找树中插入一个键值对。
    /// </summary>
    /// <param name="key">要插入的键。</param>
    /// <param name="value">要插入的值。</param>
    public void Put(TKey? key, TValue? value)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key), "calls Put() with a null key");
        if (value == null)
        {
            Delete(key);
            return;
        }
        _root = Put(_root, key, value);
    }

    /// <summary>
    /// 向二叉查找树中插入一个键值对，返回插入后的根结点。
    /// </summary>
    /// <param name="x">要插入结点的二叉查找树的根结点。</param>
    /// <param name="key">键。</param>
    /// <param name="value">值。</param>
    /// <returns>插入结点后的根结点。</returns>
    private Node Put(Node? x, TKey key, TValue? value)
    {
        if (x == null)
            return new Node(key, value, 1);

        var path = new Stack<Node>();
        var cur = x;
        while (cur != null)
        {
            path.Push(cur); 
            var cmp = key.CompareTo(cur.Key);
            if (cmp < 0)
                cur = cur.Left;
            else if (cmp > 0)
                cur = cur.Right;
            else
            {
                cur.Value = value;
                return x;
            }
        }

        var parent = path.Peek();
        var node = new Node(key, value, 1);
        if (parent.Key!.CompareTo(key) > 0)
            parent.Left = node;
        else
            parent.Right = node;

        while (path.Count > 0)
            path.Pop().Size++;
            
        return x;
    }

    /// <summary>
    /// 获得 <paramref name="key"/> 对应的值，不存在则返回 <c>default(TValue)</c>。
    /// </summary>
    /// <param name="key">需要查找的键。</param>
    /// <returns>找到的值，不存在则返回 <c>default(TValue)</c>。</returns>
    public TValue? Get(TKey key) => Get(_root, key);

    /// <summary>
    /// 查找 <paramref name="key"/> 所对应的值。
    /// </summary>
    /// <param name="x">要查找的根结点。</param>
    /// <param name="key">要查找的键。</param>
    /// <returns>如果存在则返回对应的值，否则返回 <c>default(TValue)</c>。</returns>
    private TValue? Get(Node? x, TKey? key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key), "calls get() with a null key");
        var cur = x;
        while (cur != null)
        {
            var cmp = key.CompareTo(cur.Key);
            if (cmp < 0)
                cur = cur.Left;
            else if (cmp > 0)
                cur = cur.Right;
            else
                return cur.Value;
        }

        return default;
    }

    /// <summary>
    /// 删除含有某个键的结点。
    /// </summary>
    /// <param name="key">要删除的键。</param>
    /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
    public void Delete(TKey key)
    {
        if (key == null)
            throw new InvalidOperationException("Symbol Table Underflow");
        _root = Delete(_root, key);
    }

    /// <summary>
    /// 从二叉查找树中删除键为 <paramref name="key"/> 的结点。
    /// </summary>
    /// <param name="x">要删除的结点的二叉查找树。</param>
    /// <param name="key">要删除的键。</param>
    /// <returns>删除结点后的二叉查找树。</returns>
    private Node? Delete(Node? x, TKey key)
    {
        if (x == null)
            return null;

        var cmp = key.CompareTo(x.Key);
        if (cmp < 0)
            x.Left = Delete(x.Left, key);
        else if (cmp > 0)
            x.Right = Delete(x.Right, key);
        else
        {
            if (x.Right == null)
                return x.Left;
            if (x.Left == null)
                return x.Right;
            var t = x;
            x = Min(t.Right);
            x.Right = DeleteMin(t.Right);
            x.Left = t.Left;
        }
        x.Size = Size(x.Left) + Size(x.Right) + 1;
        return x;
    }

    /// <summary>
    /// 检查二叉查找树是否含有 <paramref name="key"/>。
    /// </summary>
    /// <param name="key">要查找的键值。</param>
    /// <returns>如果含有则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
    public bool Contains(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key), "argument to Contains is null!");
        return Get(key) != null;
    }

    /// <summary>
    /// 二叉查找树是否为空。
    /// </summary>
    /// <returns>为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
    [MemberNotNullWhen(false, nameof(_root))]
    public bool IsEmpty() => Size(_root) == 0;

    /// <summary>
    /// 获取二叉查找树的结点数量。
    /// </summary>
    /// <returns>二叉查找树的结点数量。</returns>
    public int Size() => Size(_root);

    /// <summary>
    /// 获取某个结点为根的二叉树结点数量。
    /// </summary>
    /// <param name="x">根结点。</param>
    /// <returns>以 <paramref name="x"/> 为根的二叉树的结点数量。</returns>
    private int Size(Node? x)
    {
        if (x == null)
            return 0;
        return x.Size;
    }

    /// <summary>
    /// 获取符号表中键在 <paramref name="lo"/> 和 <paramref name="hi"/> 之间的键的数目。
    /// </summary>
    /// <param name="lo">键的下限。</param>
    /// <param name="hi">键的上限。</param>
    /// <returns><paramref name="lo"/> 和 <paramref name="hi"/> 之间键的数目。</returns>
    public int Size(TKey lo, TKey hi)
    {
        if (lo == null)
            throw new ArgumentNullException(nameof(lo), "first argument to Size() is null");
        if (hi == null)
            throw new ArgumentNullException(nameof(hi), "second argument to Size() is null");

        if (lo.CompareTo(hi) > 0)
            return 0;
        if (Contains(hi))
            return Rank(hi) - Rank(lo) + 1;
        return Rank(hi) - Rank(lo);
    }

    /// <summary>
    /// 获得二叉搜索树的高度。
    /// </summary>
    /// <returns>二叉搜索树的高度。</returns>
    public int Height()
    {
        return Height(_root);
    }

    /// <summary>
    /// 获得二叉搜索树的高度。
    /// </summary>
    /// <param name="x">二叉搜索树的根结点。</param>
    /// <returns>以 <paramref name="x"/> 为根结点的二叉树的高度。</returns>
    private int Height(Node? x)
    {
        if (x == null)
            return -1;
        return 1 + Math.Max(Height(x.Left), Height(x.Right));
    }

    /// <summary>
    /// 获得符号表全部的键。
    /// </summary>
    /// <returns>符号表全部的键。</returns>
    public IEnumerable<TKey> Keys()
    {
        if (IsEmpty())
            return new List<TKey>();
        return Keys(Min()!, Max()!);
    }

    /// <summary>
    /// 获取符号表中指定键之间的全部键。
    /// </summary>
    /// <param name="lo">键的下限。</param>
    /// <param name="hi">键的上限。</param>
    /// <returns>包含 <paramref name="lo"/> 和 <paramref name="hi"/> 及其之间的所有键。</returns>
    public IEnumerable<TKey> Keys(TKey lo, TKey hi)
    {
        if (lo == null)
            throw new ArgumentNullException(nameof(lo), "first argument to keys() is null");
        if (hi == null)
            throw new ArgumentNullException(nameof(hi), "second argument to keys() is null");

        var queue = new Queue<TKey>();
        Keys(_root, queue, lo, hi);
        return queue;
    }

    /// <summary>
    /// 获取二叉查找树中在 <paramref name="lo"/> 和 <paramref name="hi"/> 之间的所有键。
    /// </summary>
    /// <param name="x">二叉查找树的根结点。</param>
    /// <param name="queue">要填充的队列。</param>
    /// <param name="lo">键的下限。</param>
    /// <param name="hi">键的上限。</param>
    private static void Keys(Node? x, Queue<TKey> queue, TKey lo, TKey hi)
    {
        var stack = new Stack<Node>();

        while (x != null || stack.Count > 0)
        {
            if (x != null)
            {
                var cmpLo = lo.CompareTo(x.Key);
                var cmpHi = hi.CompareTo(x.Key);
                if (cmpHi >= 0)
                    stack.Push(x);
                if (cmpLo < 0)
                    x = x.Left;
                else
                    x = null;
            }
            else
            {
                x = stack.Pop();
                var cmpLo = lo.CompareTo(x.Key);
                var cmpHi = hi.CompareTo(x.Key);
                if (cmpLo <= 0 && cmpHi >= 0)
                    queue.Enqueue(x.Key!);
                x = x.Right;
            }
        }
    }

    /// <summary>
    /// 查找二叉查找树中的最小的键。
    /// </summary>
    /// <returns>二叉查找树中最小的键。</returns>
    /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
    public TKey? Min()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Symbol Table Underflow");
        return Min(_root).Key;
    }

    /// <summary>
    /// 在二叉查找树中查找包含最小键的结点。
    /// </summary>
    /// <param name="x">二叉查找树的根结点。</param>
    /// <returns>包含最小键的结点。</returns>
    [return: NotNullIfNotNull("x")]
    private Node? Min(Node? x)
    {
        while (x != null)
        {
            if (x.Left == null) return x;
            x = x.Left;
        }

        return x;
    }

    /// <summary>
    /// 查找二叉查找树中的最大的键。
    /// </summary>
    /// <returns>二叉查找树中最大的键。</returns>
    /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
    public TKey? Max()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Symbol Table Underflow");
        return Max(_root).Key;
    }

    /// <summary>
    /// 在二叉查找树中查找包含最大键的结点。
    /// </summary>
    /// <param name="x">二叉查找树的根结点。</param>
    /// <returns>包含最大键的结点。</returns>
    [return: NotNullIfNotNull("x")]
    private Node? Max(Node? x)
    {
        while (x != null)
        {
            if (x.Right == null) return x;
            x = x.Right;
        }

        return x;
    }

    /// <summary>
    /// 获得符号表中小于等于 <paramref name="key"/> 的最大键。
    /// </summary>
    /// <param name="key">键。</param>
    /// <returns>小于等于 <paramref name="key"/> 的最大键。</returns>
    public TKey? Floor(TKey? key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key), "argument to floor is null");
        if (IsEmpty())
            throw new InvalidOperationException("calls floor with empty symbol table");
        var x = Floor(_root, key);
        if (x == null)
            return default;
        return x.Key;
    }

    /// <summary>
    /// 获得符号表中小于等于 <paramref name="key"/> 的最大结点。
    /// </summary>
    /// <param name="x">二叉查找树的根结点。</param>
    /// <param name="key">键。</param>
    /// <returns>小于等于 <paramref name="key"/> 的最大结点。</returns>
    private Node? Floor(Node? x, TKey key)
    {
        Node? floor = null;
        while (x != null)
        {
            var cmp = key.CompareTo(x.Key);
            if (cmp == 0)
            {
                return x;
            }

            if (cmp < 0)
            {
                x = x.Left;
            }
            else
            {
                floor = x;
                x = x.Right;
            }
        }

        return floor;
    }

    /// <summary>
    /// 获取符号表中大于等于 <paramref name="key"/> 的最小键。
    /// </summary>
    /// <param name="key">键。</param>
    /// <returns>大于等于 <paramref name="key"/> 的最小键。</returns>
    public TKey? Ceiling(TKey? key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key), "argument to ceiling is null");
        if (IsEmpty())
            throw new InvalidOperationException("calls ceiling with empty symbol table");
        var x = Ceiling(_root, key);
        if (x == null)
            return default;
        return x.Key;
    }

    /// <summary>
    /// 获取符号表中大于等于 <paramref name="key"/> 的最小结点。
    /// </summary>
    /// <param name="x">二叉查找树的根结点。</param>
    /// <param name="key">键。</param>
    /// <returns>符号表中大于等于 <paramref name="key"/> 的最小结点。</returns>
    private Node? Ceiling(Node? x, TKey key)
    {
        Node? ceil = null;
        while (x != null)
        {
            var cmp = key.CompareTo(x.Key);
            if (cmp == 0)
            {
                return x;
            }
            if (cmp > 0)
            {
                x = x.Right;
            }
            else
            {
                ceil = x;
                x = x.Left;
            }
        }

        return ceil;
    }

    /// <summary>
    /// 返回 <paramref name="key"/> 在符号表中的排名。
    /// </summary>
    /// <param name="key">要排名的键。</param>
    /// <returns><paramref name="key"/> 的排名。</returns>
    public int Rank(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key), "argument to rank() is null");
        return Rank(_root, key);
    }

    /// <summary>
    /// 返回 <paramref name="key"/> 在二叉查找树中的排名。
    /// </summary>
    /// <param name="x">二叉查找树的根结点。</param>
    /// <param name="key">要查找排名的键。</param>
    /// <returns><paramref name="key"/> 的排名。</returns>
    private int Rank(Node? x, TKey key)
    {
        var rank = 0;
        while (x != null)
        {
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0)
            {
                x = x.Left;
            }
            else if (cmp > 0)
            {
                rank += 1 + Size(x.Left);
                x = x.Right;
            }
            else
            {
                rank += Size(x.Left);
                return rank;
            }

        }

        return rank;
    }

    /// <summary>
    /// 挑拣出排名为 <paramref name="k"/> 的键。
    /// </summary>
    /// <param name="k">要挑拣的排名。</param>
    /// <returns>排名为 <paramref name="k"/> 的键。</returns>
    public TKey Select(int k)
    {
        if (k < 0 || k >= Size())
            throw new ArgumentException("argument to select() is invalid: " + k);
        var x = Select(_root, k);
        return x!.Key!;
    }

    /// <summary>
    /// 挑拣出排名为 <paramref name="k"/> 的结点。
    /// </summary>
    /// <param name="x">树的根结点。</param>
    /// <param name="k">要挑拣的排名。</param>
    /// <returns>排名为 <paramref name="k"/> 的结点。</returns>
    [return: NotNullIfNotNull("x")]
    private Node? Select(Node? x, int k)
    {
        while (x != null)
        {
            var t = Size(x.Left);
            if (t > k)
            {
                x = x.Left;
            }
            else if (t < k)
            {
                x = x.Right;
                k = k - t - 1;
            }
            else
            {
                return x;
            }
        }

        return null;
    }

    /// <summary>
    /// 删除二叉查找树中最小的结点。
    /// </summary>
    /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出此异常。</exception>
    public void DeleteMin()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Symbol table underflow");
        _root = DeleteMin(_root);
    }

    /// <summary>
    /// 在以 <paramref name="x"/> 为根结点的二叉查找树中删除最小结点。
    /// </summary>
    /// <param name="x">二叉查找树的根结点。</param>
    /// <returns>删除后的二叉查找树。</returns>
    private Node? DeleteMin(Node x)
    {
        if (x.Left == null)
            return x.Right;
        x.Left = DeleteMin(x.Left);
        x.Size = Size(x.Left) + Size(x.Right) + 1;
        return x;
    }

    /// <summary>
    /// 删除二叉查找树中最大的结点。
    /// </summary>
    /// <exception cref="InvalidOperationException">当二叉查找树为空时抛出该异常。</exception>
    public void DeleteMax()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Symbol Table Underflow");
        _root = DeleteMax(_root);
    }

    /// <summary>
    /// 从指定二叉查找树中删除最大结点。
    /// </summary>
    /// <param name="x">二叉查找树的根结点。</param>
    /// <returns>删除后的二叉查找树。</returns>
    private Node? DeleteMax(Node x)
    {
        if (x.Right == null)
            return x.Left;
        x.Right = DeleteMax(x.Right);
        x.Size = 1 + Size(x.Left) + Size(x.Right);
        return x;
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

        //BST
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
                        sb.Append(" ");
                    sb.Append("|");
                    for (var i = 1; i < unitSize / 4; i++)
                        sb.Append("-");
                }
                else
                {
                    for (var i = 0; i < unitSize / 2; i++)
                        sb.Append(" ");
                }

                if (x == null)
                    sb.Append(" ");
                else
                    sb.Append(x.Key);

                if (x != null && x.Right != null)
                {
                    for (var i = 1; i < unitSize / 4; i++)
                        sb.Append("-");
                    sb.Append("|");
                    for (var i = 1; i < unitSize / 4; i++)
                        sb.Append(" ");
                }
                else
                {
                    for (var i = 1; i < unitSize / 2; i++)
                        sb.Append(" ");
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

    /// <summary>
    /// 将二叉树转变为数组表示。
    /// </summary>
    /// <returns>包含所有键值的数组。</returns>
    public TKey?[] ToKeyArray()
    {
        // 取最近的二的幂
        var size = (int)Math.Pow(2, Math.Ceiling(Math.Log(Size(), 2)));
        var result = new TKey?[size];

        // 层序遍历。
        var queue = new Queue<Node?>();
        var index = 0;
        queue.Enqueue(_root);
        while (queue.Count != 0 && index < size)
        {
            var x = queue.Dequeue();
            if (x != null)
            {
                queue.Enqueue(x.Left);
                queue.Enqueue(x.Right);

                result[index++] = x.Key;
            }

            result[index++] = default;
        }

        return result;
    }

    /// <summary>
    /// 将二叉树转变为数组表示。
    /// </summary>
    /// <returns>表示二叉树的数组。</returns>
    public TValue?[] ToValueArray()
    {
        // 取最近的二的幂
        var size = (int)Math.Pow(2, Math.Ceiling(Math.Log(Size(), 2)));
        var result = new TValue?[size];

        // 层序遍历。
        var queue = new Queue<Node?>();
        var index = 0;
        queue.Enqueue(_root);
        while (queue.Count != 0 && index < size)
        {
            var x = queue.Dequeue();
            if (x != null)
            {
                queue.Enqueue(x.Left);
                queue.Enqueue(x.Right);

                result[index++] = x.Value;
            }

            result[index++] = default;
        }

        return result;
    }

    /// <summary>
    /// 获取二叉树的最大深度。
    /// </summary>
    /// <param name="x">二叉树的根结点。</param>
    /// <returns>二叉树的最大深度。</returns>
    private int Depth(Node? x)
    {
        if (x == null)
            return 0;
        return 1 + Math.Max(Depth(x.Left), Depth(x.Right));
    }

}