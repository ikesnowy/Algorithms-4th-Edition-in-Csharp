﻿namespace _2._2._15;

/// <summary>
/// 链表结点类。
/// </summary>
/// <typeparam name="T">结点存放的元素类型。</typeparam>
public class Node<T>
{
    public T Item { get; set; } = default!;
    public Node<T>? Next { get; set; }

    public Node() { }

    public Node(Node<T> node)
    {
        Item = node.Item;
        Next = node.Next;
    }
}