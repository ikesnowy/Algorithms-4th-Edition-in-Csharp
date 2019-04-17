using System;
using SortApplication;

namespace _2._5._22
{
    
    class Program
    {
        class Ticket : IComparable<Ticket>
        {
            public double Price;
            public int Share;

            public int CompareTo(Ticket other)
            {
                return this.Price.CompareTo(other.Price);
            }
        }

        static void Main(string[] args)
        {
            // 输入格式： buy 20.05 100
            MaxPQ<Ticket> buyer = new MaxPQ<Ticket>();
            MinPQ<Ticket> seller = new MinPQ<Ticket>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Ticket ticket = new Ticket();
                string[] item = Console.ReadLine().Split(' ');

                ticket.Price = double.Parse(item[1]);
                ticket.Share = int.Parse(item[2]);
                if (item[0] == "buy")
                    buyer.Insert(ticket);
                else
                    seller.Insert(ticket);
            }

            while (!buyer.IsEmpty() && !seller.IsEmpty())
            {
                if (buyer.Max().Price < seller.Min().Price)
                    break;
                Ticket buy = buyer.DelMax();
                Ticket sell = seller.DelMin();
                Console.Write("sell $" + sell.Price + " * " + sell.Share);
                if (buy.Share > sell.Share)
                {
                    Console.WriteLine(" -> " + sell.Share + " -> $" + buy.Price + " * " + buy.Share + " buy");
                    buy.Share -= sell.Share;
                    buyer.Insert(buy);

                }
                else if (buy.Share < sell.Share)
                {
                    sell.Share -= buy.Share;
                    seller.Insert(sell);
                    Console.WriteLine(" -> " + buy.Share + " -> $" + buy.Price + " * " + buy.Share + " buy");
                }
                else
                {
                    Console.WriteLine(" -> " + sell.Share + " -> $" + buy.Price + " * " + buy.Share + " buy");
                }

            }
        }
    }
}
