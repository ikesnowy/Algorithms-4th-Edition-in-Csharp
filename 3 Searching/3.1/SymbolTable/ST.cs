using System.Collections;
using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 利用库函数实现的标准符号表。
    /// </summary>
    /// <typeparam name="Key">键的类型。</typeparam>
    /// <typeparam name="Value">值的类型。</typeparam>
    public class ST<Key, Value> : IST<Key, Value>, IEnumerable<Key>
    {
        Dictionary<Key, Value> st;

        /// <summary>
        /// 新建一个符号表。
        /// </summary>
        public ST()
        {
            this.st = new Dictionary<Key, Value>();
        }

        /// <summary>
        /// 检查符号表中是否存在与键 <paramref name="key"/> 对应的值。
        /// </summary>
        /// <param name="key">要检查是否存在的键。</param>
        /// <returns></returns>
        public virtual bool Contains(Key key)
        {
            return this.st.ContainsKey(key);
        }

        /// <summary>
        /// 从符号表中删除键 <paramref name="key"/> 及对应的值。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        public virtual void Delete(Key key)
        {
            this.st.Remove(key);
        }

        /// <summary>
        /// 获取键 <paramref name="key"/> 对应的值，不存在时返回 null。
        /// </summary>
        /// <param name="key">要查找的键。</param>
        /// <returns></returns>
        public virtual Value Get(Key key)
        {
            return this.st[key];
        }

        /// <summary>
        /// 获取枚举器。
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Key> GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 检查符号表是否为空。
        /// </summary>
        /// <returns></returns>
        public virtual bool IsEmpty()
        {
            return this.st.Count == 0;
        }

        /// <summary>
        /// 获得符号表中所有键的集合。
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Key> Keys()
        {
            return this.st.Keys;
        }

        /// <summary>
        /// 向符号表中插入新的键值对。
        /// </summary>
        /// <param name="key">要插入的键。</param>
        /// <param name="value">对应的值。</param>
        public virtual void Put(Key key, Value value)
        {
            this.st.Add(key, value);
        }

        /// <summary>
        /// 获取符号表中键值对的数量。
        /// </summary>
        /// <returns></returns>
        public virtual int Size()
        {
            return this.st.Count;
        }

        /// <summary>
        /// 获取枚举器。
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.st.Keys.GetEnumerator();
        }
    }
}
