using System;
using Generics;

var x = new Node<string> { Item = "first" };
var y = new Node<string> { Item = "second" };
x.Next = y;
var z = new Node<string> { Item = "third" };
y.Next = z;

Console.WriteLine("x: " + x.Item);
Console.WriteLine("x.next: " + x.Next.Item);
x.Next = x.Next.Next;
Console.WriteLine();
Console.WriteLine("x: " + x.Item);
Console.WriteLine("x.next: " + x.Next!.Item);