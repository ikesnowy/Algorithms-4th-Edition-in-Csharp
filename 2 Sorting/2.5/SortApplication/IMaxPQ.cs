using System;

namespace SortApplication
{
    /// <summary>
    /// 实现优先队列 API 的接口。（最大堆）
    /// </summary>
    /// <typeparam name="Key">优先队列容纳的元素。</typeparam>
    public interface IMaxPQ<Key> where Key : IComparable<Key>
    {
        /// <summary>
        /// 向优先队列中插入一个元素。
        /// </summary>
        /// <param name="v">插入元素的类型。</param>
        void Insert(Key v);

        /// <summary>
        /// 返回最大元素。
        /// </summary>
        /// <returns></returns>
        Key Max();

        /// <summary>
        /// 删除并返回最大元素。
        /// </summary>
        /// <returns></returns>
        Key DelMax();

        /// <summary>
        /// 返回队列是否为空。
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 返回队列中的元素个数。
        /// </summary>
        /// <returns></returns>
        int Size();
    }
}
