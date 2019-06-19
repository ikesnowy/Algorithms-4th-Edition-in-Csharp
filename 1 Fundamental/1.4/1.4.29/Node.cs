namespace _1._4._29
{
    /// <summary>
    /// 链表结点类。
    /// </summary>
    /// <typeparam name="T">结点中存放的元素类型。</typeparam>
    public class Node<T>
    {
        public T item;
        public Node<T> next;

        public Node() { }

        public Node(Node<T> node)
        {
            item = node.item;
            next = node.next;
        }
    }
}
