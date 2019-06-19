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
            /// <value>结点的值。</value>
            public Key Key { get; set; }
            /// <summary>
            /// 结点在当前数组中的下标。
            /// </summary>
            /// <value>结点在当前数组中的下标。</value>
            public readonly int Index;
            /// <summary>
            /// 指向孪生结点的引用。
            /// </summary>
            /// <value>指向孪生结点的引用。</value>
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
            /// <returns>如果 <paramref name="other"/> 比较小则返回正数，否则返回负数。</returns>
            public int CompareTo(MinMaxNode other)
            {
                return this.Key.CompareTo(other.Key);
            }
        }

        /// <summary>
        /// 对 <see cref="MinMaxNode"/> 偏特化的最大堆。
        /// </summary>
        private sealed class MaxPQ : MaxPQ<MinMaxNode>
        {
            /// <summary>
            /// 默认无参构造函数。
            /// </summary>
            public MaxPQ() : base() { }
            /// <summary>
            /// 建立指定大小的最大堆。
            /// </summary>
            /// <param name="capacity">最大堆的容量。</param>
            public MaxPQ(int capacity) : base(capacity) { }
            /// <summary>
            /// 利用指定的结点建立最大堆。
            /// </summary>
            /// <param name="nodes">用于建立最大堆的结点。</param>
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

                var swapNode = this.pq[i].Pair;
                var swapKey = this.pq[i].Key;

                this.pq[i].Key = this.pq[j].Key;
                this.pq[i].Pair = this.pq[j].Pair;

                this.pq[j].Key = swapKey;
                this.pq[j].Pair = swapNode;
            }
        }

        /// <summary>
        /// 对 <see cref="MinMaxNode"/> 偏特化的最小堆。
        /// </summary>
        private sealed class MinPQ : MinPQ<MinMaxNode>
        {
            /// <summary>
            /// 默认无参构造函数。
            /// </summary>
            public MinPQ() : base() { }
            /// <summary>
            /// 建立指定大小的最小堆。
            /// </summary>
            /// <param name="capacity">最小堆的容量。</param>
            public MinPQ(int capacity) : base(capacity) { }
            /// <summary>
            /// 利用指定的结点建立最小堆。
            /// </summary>
            /// <param name="nodes">用于建立最小堆的结点。</param>
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
        /// <value>最小堆。</value>
        private MinPQ minPQ;
        /// <summary>
        /// 最大堆。
        /// </summary>
        /// <value>最大堆。</value>
        private MaxPQ maxPQ;
        /// <summary>
        /// 堆的大小。
        /// </summary>
        /// <value>堆的大小。</value>
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
            var minNodes = new MinMaxNode[keys.Length];
            var maxNodes = new MinMaxNode[keys.Length];
            for (var i = 0; i < this.n; i++)
            {
                MinMaxNode.GetNodes(keys[i], i + 1, out minNodes[i], out maxNodes[i]);
            }
            this.minPQ = new MinPQ(minNodes);
            this.maxPQ = new MaxPQ(maxNodes);
        }

        /// <summary>
        /// 删除并返回最大值。
        /// </summary>
        /// <returns>最大元素。</returns>
        public Key DelMax()
        {
            // ⬇ 不可以交换操作顺序 ⬇
            this.minPQ.Remove(this.maxPQ.Max().Pair.Index);
            var key = this.maxPQ.Max().Key;
            this.maxPQ.DelMax();
            // ⬆ 不可以交换操作顺序 ⬆
            this.n--;
            return key;
        }

        /// <summary>
        /// 删除并返回最小值。
        /// </summary>
        /// <returns>最小值。</returns>
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
            MinMaxNode.GetNodes(v, this.n, out var minNode, out var maxNode);
            this.maxPQ.Insert(maxNode);
            this.minPQ.Insert(minNode);
        }

        /// <summary>
        /// 判断堆是否为空。
        /// </summary>
        /// <returns>若堆为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 获得堆中的最大值。
        /// </summary>
        /// <returns>堆的最大值。</returns>
        public Key Max() => this.maxPQ.Max().Key;

        /// <summary>
        /// 获得堆中的最小值。
        /// </summary>
        /// <returns>堆的最小值。</returns>
        public Key Min() => this.minPQ.Min().Key;

        /// <summary>
        /// 获得堆的大小。
        /// </summary>
        /// <returns>堆的大小。</returns>
        public int Size() => this.n;
    }
}
