﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2._2._17;

/// <summary>
/// 链表类。
/// </summary>
/// <typeparam name="TItem">链表存放的元素类型。</typeparam>
public class LinkedList<TItem> : IEnumerable<TItem>
{
    private Node<TItem>? _first;
    private int _count;

    /// <summary>
    /// 建立一条链表。
    /// </summary>
    public LinkedList()
    {
        _first = null;
        _count = 0;
    }

    /// <summary>
    /// 在表头插入一个元素。
    /// </summary>
    /// <param name="item">要插入的元素。</param>
    public void Insert(TItem item)
    {
        var n = new Node<TItem> { Item = item, Next = _first };
        _first = n;
        _count++;
    }

    /// <summary>
    /// 在指定位置前面插入一个元素。
    /// </summary>
    /// <param name="item">要插入的元素。</param>
    /// <param name="position">要插入的位置。（从 0 开始）</param>
    public void Insert(TItem item, int position)
    {
        if (position > _count)
        {
            throw new IndexOutOfRangeException();
        }
        if (position == 0)
        {
            Insert(item);
            return;
        }

        var n = new Node<TItem> { Item = item };

        var front = _first;
        for (var i = 1; i < position; i++)
        {
            front = front!.Next;
        }

        n.Next = front!.Next;
        front.Next = n;
        _count++;
    }

    /// <summary>
    /// 获取指定位置的元素。
    /// </summary>
    /// <param name="index">元素下标。</param>
    /// <returns></returns>
    public TItem Find(int index)
    {
        if (index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        var current = _first;
        for (var i = 0; i < index; i++)
        {
            current = current!.Next;
        }

        return current!.Item;
    }

    /// <summary>
    /// 删除指定位置的元素，返回该元素。
    /// </summary>
    /// <param name="index">需要删除元素的位置。</param>
    /// <returns></returns>
    public TItem Delete(int index)
    {
        if (index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        var front = _first;
        var temp = _first!.Item;
        if (index == 0)
        {
            _first = _first.Next;
            _count--;
            return temp;
        }

        for (var i = 1; i < index; i++)
        {
            front = front!.Next;
        }

        temp = front!.Next!.Item;
        front.Next = front.Next.Next;
        _count--;
        return temp;
    }

    /// <summary>
    /// 检查链表是否为空。
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return _count == 0;
    }

    /// <summary>
    /// 获取链表中元素的数量。
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        return _count;
    }

    /// <summary>
    /// 将链表转化成单个字符串，元素之间用空格隔开。
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var s = new StringBuilder();

        foreach (var i in this)
        {
            s.Append(i);
            s.Append(" ");
        }

        return s.ToString();
    }

    /// <summary>
    /// 获得表头结点。
    /// </summary>
    /// <returns>表头结点</returns>
    public Node<TItem>? GetFirst() => _first;

    /// <summary>
    /// 设置表头结点。
    /// </summary>
    /// <param name="first">新的表头结点。</param>
    public void SetFirst(Node<TItem> first) => _first = first;

    public IEnumerator<TItem> GetEnumerator()
    {
        return new LinkedListEnumerator(_first);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LinkedListEnumerator : IEnumerator<TItem>
    {
        private Node<TItem>? _current;
        private Node<TItem>? _first;

        public LinkedListEnumerator(Node<TItem>? first)
        {
            _current = new Node<TItem> { Next = first };
            _first = _current;
        }

        TItem IEnumerator<TItem>.Current => _current!.Item;

        object IEnumerator.Current => _current!.Item!;

        void IDisposable.Dispose()
        {
            _first = null;
            _current = null;
        }

        bool IEnumerator.MoveNext()
        {
            if (_current?.Next == null)
                return false;
            _current = _current.Next;
            return true;
        }

        void IEnumerator.Reset()
        {
            _current = _first;
        }
    }
}