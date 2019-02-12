using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 有序符号表接口。
    /// </summary>
    /// <typeparam name="Key">键类型。</typeparam>
    /// <typeparam name="Value">值类型。</typeparam>
    public interface IOrderedST<Key, Value>
    {
        /// <summary>
        /// 向符号表插入键值对。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        void Put(Key key, Value value);

        /// <summary>
        /// 获取键 <paramref name="key"/> 对应的值，不存在则返回 null。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns></returns>
        Value Get(Key key);

        /// <summary>
        /// 从表中删去键 <paramref name="key"/> 对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        void Delete(Key key);

        /// <summary>
        /// 键 <paramref name="key"/> 在表中是否存在对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns></returns>
        bool Contains(Key key);

        /// <summary>
        /// 符号表是否为空。
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 获得符号表中键值对的数量。
        /// </summary>
        /// <returns></returns>
        int Size();

        /// <summary>
        /// [<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数量。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns></returns>
        int Size(Key lo, Key hi);

        /// <summary>
        /// 获得符号表中所有键的集合。
        /// </summary>
        /// <returns></returns>
        IEnumerable<Key> Keys();

        /// <summary>
        /// 获得符号表中 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键。
        /// </summary>
        /// <param name="lo">范围起点。</param>
        /// <param name="hi">范围终点。</param>
        /// <returns></returns>
        IEnumerable<Key> Keys(Key lo, Key hi);

        /// <summary>
        /// 最小的键。
        /// </summary>
        /// <returns></returns>
        Key Min();

        /// <summary>
        /// 最大的键。
        /// </summary>
        /// <returns></returns>
        Key Max();

        /// <summary>
        /// 小于等于 Key 的最大值。
        /// </summary>
        /// <returns></returns>
        Key Floor(Key key);

        /// <summary>
        /// 大于等于 key 的最小值。
        /// </summary>
        /// <returns></returns>
        Key Ceiling(Key key);

        /// <summary>
        /// 小于 Key 的键的数量。
        /// </summary>
        /// <returns></returns>
        int Rank(Key key);

        /// <summary>
        /// 排名为 k 的键。
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        Key Select(int k);

        /// <summary>
        /// 删除最小的键。
        /// </summary>
        void DeleteMin();

        /// <summary>
        /// 删除最大的键。
        /// </summary>
        void DeleteMax();
    }
}
