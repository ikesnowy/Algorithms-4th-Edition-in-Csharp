using System;

namespace PriorityQueue
{
    /// <summary>
    /// 基于链式结构实现的最大堆。
    /// </summary>
    /// <typeparam name="Key">优先队列中保存的数据类型。</typeparam>
    public class MaxPQLinked<Key> : IMaxPQ<Key> where Key : IComparable<Key>
    {
        /// <summary>
        /// 二叉堆的根结点。
        /// </summary>
        private TreeNode<Key> root = null;
        /// <summary>
        /// 二叉堆的最后一个结点。
        /// </summary>
        private TreeNode<Key> last = null;
        /// <summary>
        /// 二叉堆中的结点个数。
        /// </summary>
        private int nodesCount = 0;

        /// <summary>
        /// 建立一个链式结构的最大堆。
        /// </summary>
        public MaxPQLinked() { }

        /// <summary>
        /// 删除并返回最大值。
        /// </summary>
        /// <returns>最大值。</returns>
        public Key DelMax()
        {
            Key result = this.root.Value;
            Exch(this.root, this.last);

            if (this.nodesCount == 2)
            {
                this.root.Left = null;
                this.last = this.root;
                this.nodesCount--;
                return result;
            }
            else if (this.nodesCount == 1)
            {
                this.last = null;
                this.root = null;
                this.nodesCount--;
                return result;
            }

            // 获得前一个结点。
            TreeNode<Key> newLast = this.last;
            if (newLast == this.last.Prev.Right)
                newLast = this.last.Prev.Left;
            else
            {
                // 找到上一棵子树。
                while (newLast != this.root)
                {
                    if (newLast != newLast.Prev.Left)
                        break;
                    newLast = newLast.Prev;
                }

                // 已经是满二叉树。
                if (newLast == this.root)
                {
                    // 一路向右，回到上一层。
                    while (newLast.Right != null)
                        newLast = newLast.Right;
                }
                // 不是满二叉树。
                else
                {
                    // 向左子树移动，再一路向右。
                    newLast = newLast.Prev.Left;
                    while (newLast.Right != null)
                        newLast = newLast.Right;
                }
            }

            // 删除最后一个结点。
            if (this.last.Prev.Left == this.last)
                this.last.Prev.Left = null;
            else
                this.last.Prev.Right = null;

            Sink(this.root);

            // 指向新的最后一个结点。
            this.last = newLast;
            this.nodesCount--;
            return result;
        }

        /// <summary>
        /// 插入一个新的结点。
        /// </summary>
        /// <param name="v">待插入的结点。</param>
        public void Insert(Key v)
        {
            TreeNode<Key> item = new TreeNode<Key>(v);
            // 堆为空。
            if (this.last == null)
            {
                this.root = item;
                this.last = item;
                this.nodesCount++;
                return;
            }
            
            // 堆只有一个结点。
            if (this.last == this.root)
            {
                item.Prev = this.root;
                this.root.Left = item;
                this.last = item;
                this.nodesCount++;
                Swim(item);
                return;
            }

            // 定位到最后一个节点的父结点。
            TreeNode<Key> prev = this.last.Prev;

            // 右子节点为空，插入到右子节点。
            if (prev.Right == null)
            {
                item.Prev = prev;
                prev.Right = item;
            }
            else
            {
                // 当前子树已满，需要向上回溯。
                // 找到下一个子树（回溯的时候是从左子树回溯上去的）。
                while (prev != this.root)
                {
                    if (prev != prev.Prev.Right)
                        break;
                    prev = prev.Prev;
                }

                // 已经是满二叉树。
                if (prev == this.root)
                {
                    // 一路向左，进入下一层。
                    while (prev.Left != null)
                        prev = prev.Left;

                    item.Prev = prev;
                    prev.Left = item;
                }
                // 不是满二叉树。
                else
                {
                    // 向右子树移动，再一路向左。
                    prev = prev.Prev.Right;
                    while (prev.Left != null)
                        prev = prev.Left;

                    item.Prev = prev;
                    prev.Left = item;
                }
            }

            this.last = item;
            this.nodesCount++;
            Swim(item);
            return;
        }

        /// <summary>
        /// 返回二叉堆是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => this.root == null;

        /// <summary>
        /// 返回二叉堆中的最大值。
        /// </summary>
        /// <returns></returns>
        public Key Max() => this.root.Value;

        /// <summary>
        /// 返回二叉堆中的元素个数。
        /// </summary>
        /// <returns></returns>
        public int Size() => this.nodesCount;

        /// <summary>
        /// 使结点上浮。
        /// </summary>
        /// <param name="k">需要上浮的结点。</param>
        private void Swim(TreeNode<Key> k)
        {
            while (k.Prev != null)
            {
                if (Less(k.Prev, k))
                {
                    Exch(k.Prev, k);
                    k = k.Prev;
                }
                else
                    break;
            }
        }

        /// <summary>
        /// 使结点下沉。
        /// </summary>
        /// <param name="k">需要下沉的结点。</param>
        private void Sink(TreeNode<Key> k)
        {
            while (k.Left != null || k.Right != null)
            {
                TreeNode<Key> toExch = null;
                if (k.Left != null && k.Right != null)
                    toExch = Less(k.Left, k.Right) ? k.Right : k.Left;
                else if (k.Left != null)
                    toExch = k.Left;
                else
                    toExch = k.Right;

                if (Less(k, toExch))
                    Exch(k, toExch);
                else
                    break;
                k = toExch;
            }
        }

        /// <summary>
        /// 交换二叉堆中的两个结点。
        /// </summary>
        /// <param name="a">要交换的第一个结点。</param>
        /// <param name="b">要交换的第二个结点。</param>
        private void Exch(TreeNode<Key> a, TreeNode<Key> b)
        {
            Key temp = a.Value;
            a.Value = b.Value;
            b.Value = temp;
        }

        /// <summary>
        /// 比较第一个结点值的是否小于第二个。
        /// </summary>
        /// <param name="a">判断是否较小的结点。</param>
        /// <param name="b">判断是否较大的结点。</param>
        /// <returns></returns>
        private bool Less(TreeNode<Key> a, TreeNode<Key> b)
            => a.Value.CompareTo(b.Value) < 0;
    }
}
