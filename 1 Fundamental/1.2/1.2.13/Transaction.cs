using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._13
{
    class Transaction : IComparable<Transaction>
    {
        public string Who { get; }
        public Date When { get; }
        public double Amount { get; }

        Transaction(string who, Date when, double amount)
        {
            this.Who = who;
            this.When = when;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return 
        }
    }
}
