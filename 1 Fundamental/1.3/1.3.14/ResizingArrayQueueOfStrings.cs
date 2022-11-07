﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._14;

/// <summary>
/// 可变长度的队列。
/// </summary>
/// <typeparam name="TItem">队列中要存放的元素。</typeparam>
internal class ResizingArrayQueueOfStrings<TItem> : IEnumerable<TItem>
{
    private TItem?[] _q;
    private int _count;
    private int _first;
    private int _last;

    public ResizingArrayQueueOfStrings()
    {
        _q = new TItem[2];
        _count = 0;
        _first = 0;

    }

    public bool IsEmpty()
    {
        return _count == 0;
    }

    public int Size()
    {
        return _count;
    }

    private void Resize(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentException("capacity should be above zero");
        var temp = new TItem?[capacity];
        for (var i = 0; i < _count; i++)
        {
            temp[i] = _q[(_first + i) % _q.Length];
        }

        _q = temp;
        _first = 0;
        _last = _count;
    }

    public void Enqueue(TItem item)
    {
        if (_count == _q.Length)
        {
            Resize(_count * 2);
        }

        _q[_last] = item;
        _last++;
        if (_last == _q.Length)
            _last = 0;
        _count++;
    }

    public TItem? Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue underflow");
        var item = _q[_first];
        _q[_first] = default!;
        _count--;
        _first++;
        if (_first == _q.Length)
            _first = 0;

        if (_count > 0 && _count <= _q.Length / 4)
            Resize(_q.Length / 2);
        return item;
    }

    public TItem? Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue underflow");
        return _q[_first];
    }

    public IEnumerator<TItem> GetEnumerator()
    {
        return new QueueEnumerator(_q, _first, _last);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class QueueEnumerator : IEnumerator<TItem>
    {
        private int _current;
        private readonly int _first;
        private readonly int _last;
        private readonly TItem?[] _q;

        public QueueEnumerator(TItem?[] q, int first, int last)
        {
            _current = first - 1;
            _first = first;
            _last = last;
            _q = q;
        }

        TItem IEnumerator<TItem>.Current => _q[_current]!;

        object IEnumerator.Current => _q[_current]!;

        void IDisposable.Dispose()
        {
                
        }

        bool IEnumerator.MoveNext()
        {
            if (_current == _last - 1)
                return false;
            _current++;
            return true;
        }

        void IEnumerator.Reset()
        {
            _current = _first - 1;
        }
    }
}