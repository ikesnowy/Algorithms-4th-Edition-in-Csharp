using System;

namespace PriorityQueue
{
    /// <summary>
    /// 最大-最小堆。
    /// </summary>
    /// <typeparam name="Key">最大最小堆中保存的元素。</typeparam>
    public class MinMaxPQ<Key> : IMaxPQ<Key>, IMinPQ<Key> where Key : IComparable<Key>
    {
        /// <summary>
        /// 最大-最小堆中的数据结点。
        /// </summary>
        private sealed class MinMaxNode : IComparable<MinMaxNode>
        {
            /// <summary>
            /// 结点的值。
            /// </summary>
            public Key Key { get; set; }
            /// <summary>
            /// 结点在当前数组中的下标。
            /// </summary>
            public readonly int Index;
            /// <summary>
            /// 指向孪生结点的引用。
            /// </summary>
            public MinMaxNode Pair { get; set; }

            /// <summary>
            /// 这个类不能在外部实例化。
            /// </summary>
            private MinMaxNode(Key key, int index)
            {
                this.Key = key;
                this.Index = index;
            }

            /// <summary>
            /// 工厂方法，建立两个孪生的结点。
            /// </summary>
            /// <param name="key">结点中的元素。</param>
            /// <param name="minNode">准备放到最小堆中的结点。</param>
            /// <param name="maxNodeB">准备放到最大堆中的结点。</param>
            public static void GetNodes(Key key, int index, out MinMaxNode minNode, out MinMaxNode maxNode)
            {
                minNode = new MinMaxNode(key, index);
                maxNode = new MinMaxNode(key, index);
                minNode.Pair = maxNode;
                maxNode.Pair = minNode;
            }

            /// <summary>
            /// 比较两个元素的大小。
            /// </summary>
            /// <param name="other">需要与之比较的另一个元素。</param>
            /// <returns></returns>
            public int CompareTo(MinMaxNode other)
            {
                return this.Key.CompareTo(other.Key);
            }
        }

        /// <summary>
        /// 偏特化的最大堆。
        /// </summary>
        private sealed class MaxPQ : MaxPQ<MinMaxNode>
        {
            public MaxPQ() : base() { }
            public MaxPQ(int capacity) : base(capacity) { }
            public MaxPQ(MinMaxNode[] nodes) : base(nodes) { }

            /// <summary>
            /// 重写的 Exch 方法，只交换元素和指针。
            /// </summary>
            /// <param name="i">要交换的下标。</param>
            /// <param name="j">要交换的下标。</param>
            protected override void Exch(int i, int j)
            {
                this.pq[i].Pair.Pair = this.pq[j];
                this.pq[j].Pair.Pair = this.pq[i];

                MinMaxNode swapNode = this.pq[i].Pair;
                Key swapKey = this.pq[i].Key;

                this.pq[i].Key = this.pq[j].Key;
                this.pq[i].Pair = this.pq[j].Pair;

                this.pq[j].Key = swapKey;
                this.pq[j].Pair = swapNode;
            }
        }

        /// <summary>
        /// 偏特化的最大堆。
        /// </summary>
        private sealed class MinPQ : MinPQ<MinMaxNode>
        {
            public MinPQ() : base() { }
            public MinPQ(int capacity) : base(capacity) { }
            public MinPQ(MinMaxNode[] nodes) : base(nodes) { }

            /// <summary>
            /// 重写的 Exch 方法，只交换元素和指针。
            /// </summary>
            /// <param name="i">要交换的下标。</param>
            /// <param name="j">要交换的下标。</param>
            protected override void Exch(int i, int j)
            {
                this.pq[i].Pair.Pair = this.pq[j];
                this.pq[j].Pair.Pair = this.pq[i];

                MinMaxNode swapNode = this.pq[i].Pair;
                Key swapKey = this.pq[i].Key;

                this.pq[i].Key = this.pq[j].Key;
                this.pq[i].Pair = this.pq[j].Pair;

                this.pq[j].Key = swapKey;
                this.pq[j].Pair = swapNode;
            }
        }

        /// <summary>
        /// 最小堆。
        /// </summary>
        private MinPQ minPQ;
        /// <summary>
        /// 最大堆。
        /// </summary>
        private MaxPQ maxPQ;
        /// <summary>
        /// 堆的大小。
        /// </summary>
        private int n;

        /// <summary>
        /// 构造一个最大-最小堆。
        /// </summary>
        public MinMaxPQ() : this(1) { }

        /// <summary>
        /// 构造一个指定容量的最大-最小堆。
        /// </summary>
        /// <param name="capacity">堆的大小。</param>
        public MinMaxPQ(int capacity)
        {
            this.minPQ = new MinPQ(capacity);
            this.maxPQ = new MaxPQ(capacity);
            this.n = 0;
        }

        /// <summary>
        /// 根据已有元素建立一个最大-最小堆。（O(n)）
        /// </summary>
        /// <param name="keys">需要建堆的元素。</param>
        public MinMaxPQ(Key[] keys)
        {
            this.n = keys.Length;
            MinMaxNode[] minNodes = new MinMaxNode[keys.Length];
            MinMaxNode[] maxNodes = new MinMaxNode[keys.Length];
            for (int i = 0; i < this.n; i++)
            {
                MinMaxNode.GetNodes(keys[i], i + 1, out minNodes[i], out maxNodes[i]);
            }
            this.minPQ = new MinPQ(minNodes);
            this.maxPQ = new MaxPQ(maxNodes);
        }

        /// <summary>
        /// 删除并返回最大值。
        /// </summary>
        /// <returns></returns>
        public Key DelMax()
        {
            // ⬇ 不可以交换操作顺序 ⬇
            this.minPQ.Remove(this.maxPQ.Max().Pair.Index);
            Key key = this.maxPQ.Max().Key;
            this.maxPQ.DelMax();
            // ⬆ 不可以交换操作顺序 ⬆
            this.n--;
            return key;
        }

        /// <summary>
        /// 删除并返回最小值。
        /// </summary>
        /// <returns></returns>
        public Key DelMin()
        {
            // ⬇ 不可以交换操作顺序 ⬇
            this.maxPQ.Remove(this.minPQ.Min().Pair.Index);
            Key key = this.minPQ.Min().Key;
            this.minPQ.DelMin();
            // ⬆ 不可以交换操作顺序 ⬆
            this.n--;
            return key;
        }

        /// <summary>
        /// 插入一个新的值。
        /// </summary>
        /// <param name="v">待插入的新值。</param>
        public void Insert(Key v)
        {
            this.n++;
            MinMaxNode.GetNodes(v, this.n, out MinMaxNode minNode, out MinMaxNode maxNode);
            this.maxPQ.Insert(maxNode);
            this.minPQ.Insert(minNode);
        }

        /// <summary>
        /// 判断堆是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 获得堆中的最大值。
        /// </summary>
        /// <returns></returns>
        public Key Max() => this.maxPQ.Max().Key;

        /// <summary>
        /// 获得堆中的最小值。
        /// </summary>
        /// <returns></returns>
        public Key Min() => this.minPQ.Min().Key;

        /// <summary>
        /// 获得堆的大小。
        /// </summary>
        /// <returns></returns>
        public int Size() => this.n;
    }
}
