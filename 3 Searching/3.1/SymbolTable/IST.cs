using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 符号表 API。
    /// </summary>
    interface IST<Key, Value>
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
        /// 获得符号表中所有键的集合。
        /// </summary>
        /// <returns></returns>
        IEnumerable<Key> Keys();
    }
}
