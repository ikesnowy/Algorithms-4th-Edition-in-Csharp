using System;
using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 基于有序链表的有序符号表实现。
    /// </summary>
    /// <typeparam name="Key">符号表键类型。</typeparam>
    /// <typeparam name="Value">符号表值类型。</typeparam>
    public class OrderedSequentialSearchST<Key, Value> : IST<Key, Value>, IOrderedST<Key, Value> 
        where Key : IComparable<Key>
    {
        /// <summary>
        /// 符号表结点。
        /// </summary>
        private class Node
        {
            public Key Key { get; set; }        // 键。
            public Value Value { get; set; }    // 值。
            public Node Next { get; set; }      // 后继。
            public Node Prev { get; set; }      // 前驱。
        }

        private Node first = null;      // 起始结点。
        private Node tail = null;       // 末尾结点。
        private int n = 0;              // 键值对数量。

        /// <summary>
        /// 构造基于有序链表的有序符号表。
        /// </summary>
        public OrderedSequentialSearchST() { }

        /// <summary>
        /// 大于等于 key 的最小值。
        /// </summary>
        /// <returns></returns>
        public Key Ceiling(Key key)
        {
            Node pointer = this.first;
            while (pointer != null && Less(pointer.Key, key))
                pointer = pointer.Next;
            return pointer == null ? default(Key) : pointer.Key;
        }

        /// <summary>
        /// 键 <paramref name="key"/> 在表中是否存在对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns></returns>
        public bool Contains(Key key) => Floor(key).Equals(key);

        /// <summary>
        /// 从表中删去键 <paramref name="key"/> 对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        public void Delete(Key key)
        {
            Node pointer = this.first;
            while (pointer != null && !pointer.Key.Equals(key))
                pointer = pointer.Next;
            if (pointer == null)
                return;
            Delete(pointer);
        }

        /// <summary>
        /// 从链表中删除结点 <paramref name="node"/>。
        /// </summary>
        /// <param name="node">待删除的结点。</param>
        private void Delete(Node node)
        {
            Node prev = node.Prev;
            Node next = node.Next;
            if (prev == null)
                this.first = next;
            else
                prev.Next = next;

            if (next == null)
                this.tail = prev;
            this.n--;
        }

        /// <summary>
        /// 删除最大的键。
        /// </summary>
        public void DeleteMax()
        {
            if (this.n == 0)
                throw new Exception("ST Underflow");
            Delete(this.tail);
        }

        /// <summary>
        /// 删除最小的键。
        /// </summary>
        public void DeleteMin()
        {
            if (this.n == 0)
                throw new Exception("ST Underflow");
            Delete(this.first);
        }

        /// <summary>
        /// 小于等于 Key 的最大值。
        /// </summary>
        /// <returns></returns>
        public Key Floor(Key key)
        {
            Node pointer = this.tail;
            while (pointer != null && Greater(pointer.Key, key))
                pointer = pointer.Prev;
            return pointer == null ? default(Key) : pointer.Key;
        }

        /// <summary>
        /// 获取键 <paramref name="key"/> 对应的值，不存在则返回 null。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns></returns>
        public Value Get(Key key)
        {
            Node pointer = this.first;
            while (pointer != null && Greater(key, pointer.Key))
                pointer = pointer.Next;

            if (pointer == null)
                return default(Value);
            else if (pointer.Key.Equals(key))
                return pointer.Value;
            else
                return default(Value);
        }

        /// <summary>
        /// 符号表是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 获得符号表中所有键的集合。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Key> Keys() => this.n == 0 ? new List<Key>() : Keys(this.first.Key, this.tail.Key);

        /// <summary>
        /// 获得符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns></returns>
        public IEnumerable<Key> Keys(Key lo, Key hi)
        {
            List<Key> list = new List<Key>();
            Node pointer = this.first;
            while (pointer != null && Less(pointer.Key, lo))
                pointer = pointer.Next;
            while (pointer != null && Less(pointer.Key, hi))
            {
                list.Add(pointer.Key);
                pointer = pointer.Next;
            }
            if (pointer.Key.Equals(hi))
                list.Add(pointer.Key);
            return list;
        }

        /// <summary>
        /// 最大的键。
        /// </summary>
        /// <returns></returns>
        public Key Max() => this.tail == null ? default(Key) : this.tail.Key;

        /// <summary>
        /// 最小的键。
        /// </summary>
        /// <returns></returns>
        public Key Min() => this.first == null ? default(Key) : this.first.Key;

        /// <summary>
        /// 向符号表插入键值对，重复值将被替换。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public void Put(Key key, Value value)
        {
            Delete(key);

            Node temp = new Node()
            {
                Key = key,
                Value = value,
                Prev = null,
                Next = null
            };

            Node left = null, right = this.first;
            while (right != null && Less(right.Key, temp.Key))
            {
                left = right;
                right = right.Next;
            }

            Insert(left, right, temp);

            if (left == null)
                this.first = temp;
            if (right == null)
                this.tail = temp;
            this.n++;
        }

        /// <summary>
        /// 小于 Key 的键的数量。
        /// </summary>
        /// <returns></returns>
        public int Rank(Key key)
        {
            int counter = 0;
            Node pointer = this.first;
            while (pointer != null && Less(pointer.Key, key))
            {
                pointer = pointer.Next;
                counter++;
            }
            return counter;
        }

        /// <summary>
        /// 获得排名为 k 的键（从 0 开始）。
        /// </summary>
        /// <param name="k">排名</param>
        /// <returns></returns>
        public Key Select(int k)
        {
            if (k >= this.n)
                throw new Exception("k must less than ST size!");

            Node pointer = this.first;
            for (int i = 0; i < k; i++)
                pointer = pointer.Next;
            return pointer.Key;
        }

        /// <summary>
        /// 获得符号表中键值对的数量。
        /// </summary>
        /// <returns></returns>
        public int Size() => this.n;

        /// <summary>
        /// [<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns></returns>
        public int Size(Key lo, Key hi)
        {
            int counter = 0;
            Node pointer = this.first;
            while (pointer != null && Less(pointer.Key, lo))
                pointer = pointer.Next;
            while (pointer != null && Less(pointer.Key, hi))
            {
                pointer = pointer.Next;
                counter++;
            }
            return counter;
        }

        /// <summary>
        /// 键 <paramref name="a"/> 是否小于 <paramref name="b"/>。
        /// </summary>
        /// <param name="a">检查是否较小的键。</param>
        /// <param name="b">检查是否较大的键。</param>
        /// <returns></returns>
        private bool Less(Key a, Key b) => a.CompareTo(b) < 0;

        /// <summary>
        /// 键 <paramref name="a"/> 是否大于 <paramref name="b"/>。
        /// </summary>
        /// <param name="a">检查是否较大的键。</param>
        /// <param name="b">检查是否较小的键。</param>
        /// <returns></returns>
        private bool Greater(Key a, Key b) => a.CompareTo(b) > 0;

        /// <summary>
        /// 将结点 <paramref name="k"/> 插入到 <paramref name="left"/> 和 <paramref name="right"/> 之间。
        /// </summary>
        /// <param name="left">作为前驱的结点。</param>
        /// <param name="right">作为后继的结点。</param>
        /// <param name="insert">待插入的结点。</param>
        private void Insert(Node left, Node right, Node k)
        {
            k.Prev = left;
            k.Next = right;
            if (left != null)
                left.Next = k;

            if (right != null)
                right.Prev = k;
        }
    }
}
