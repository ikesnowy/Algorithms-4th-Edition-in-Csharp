using System;

namespace PriorityQueue
{
    /// <summary>
    /// 带有先驱引用的二叉树结点类。
    /// </summary>
    /// <typeparam name="T">结点元素的类型。</typeparam>
    internal class TreeNode<T> where T : IComparable<T>
    {
        /// <summary>
        /// 父结点引用。
        /// </summary>
        /// <value>父节点引用。</value>
        public TreeNode<T> Prev { get; set; }
        /// <summary>
        /// 左子树的引用。
        /// </summary>
        /// <value>左子结点的引用。</value>
        public TreeNode<T> Left { get; set; }
        /// <summary>
        /// 右子树的引用。
        /// </summary>
        /// <value>右子结点的引用。</value>
        public TreeNode<T> Right { get; set; }
        /// <summary>
        /// 当前结点的值。
        /// </summary>
        /// <value>当前结点的值。</value>
        public T Value { get; set; }
        
        /// <summary>
        /// 构造器，建立一个引用全部为 null 的结点。
        /// </summary>
        /// <param name="value">结点的值。</param>
        public TreeNode(T value)
        {
            this.Value = value;
            this.Prev = null;
            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// 构造器，建立一个带父结点引用的二叉树结点。
        /// </summary>
        /// <param name="prev">父结点的引用。</param>
        /// <param name="left">左子树的引用。</param>
        /// <param name="right">右子树的引用。</param>
        /// <param name="value">当前结点的值。</param>
        public TreeNode(TreeNode<T> prev, TreeNode<T> left, TreeNode<T> right, T value)
        {
            this.Prev = prev;
            this.Left = left;
            this.Right = right;
            this.Value = value;
        }
    }
}
