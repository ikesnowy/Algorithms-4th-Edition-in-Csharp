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
            if (double.IsNaN(amount) || double.IsInfinity(amount))
            {
                throw new ArgumentException("Amount cannot be NaN or Infinity");
            }
            this.Who = who;
            this.When = when;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return string.Format("%-10s %10s %8.2f", Who, When, Amount);
        }

        int IComparable<Transaction>.CompareTo(Transaction other)
        {
            if (this.Amount < other.Amount)
                return -1;
            if (this.Amount > other.Amount)
                return 1;
            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Transaction that = (Transaction)obj;

            return
                (that.Amount == this.Amount) &&
                (that.When == this.When) &&
                (that.Who == this.Who);
        }

        public override int GetHashCode()
        {
            int hash = 1;
            hash = 31 * hash + Who.GetHashCode();
            hash = 31 * hash + When.GetHashCode();
            hash = 31 * hash + Amount.GetHashCode();
            return hash;
        }
    }
}
