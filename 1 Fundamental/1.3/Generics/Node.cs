namespace Generics
{
    public class Node<T>
    {
        public T item;
        public Node<T> next;

        public Node() { }

        public Node(Node<T> node)
        {
            this.item = node.item;
            this.next = node.next;
        }
    }
}
