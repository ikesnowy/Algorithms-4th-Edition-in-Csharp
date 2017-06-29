using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Node<T>
    {
        public T item;
        public Node<T> next;
    }
}
