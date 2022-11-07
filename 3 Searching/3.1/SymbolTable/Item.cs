using System;
using System.Collections.Generic;

namespace SymbolTable;

/// <summary>
/// 键值对结点。
/// </summary>
/// <typeparam name="TKey">键类型。</typeparam>
/// <typeparam name="TValue">值类型。</typeparam>
public class Item<TKey, TValue> : IComparable<Item<TKey, TValue>>
    where TKey : IComparable<TKey>
{
    public TKey? Key { get; set; }
    public TValue? Value { get; set; }

    public int CompareTo(Item<TKey, TValue>? other)
    {
        if (other == null)
        {
            return 1;
        }


        return Comparer<TKey>.Default.Compare(Key, other.Key);
    }
}