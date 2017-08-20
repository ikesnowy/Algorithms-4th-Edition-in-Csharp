using System;
using System.Collections.Generic;

namespace _1._3._17
{
    public class Transaction : IComparable<Transaction>
    {
        public string Who { get; }
        public Date When { get; }
        public double Amount { get; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="transaction">用空格隔开的形如 “姓名 日期 金额” 的字符串。</param>
        public Transaction(string transaction)
        {
            string[] a = transaction.Split(' ');
            this.Who = a[0];
            this.When = new Date(a[1]);
            this.Amount = double.Parse(a[2]);
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="who">客户姓名。</param>
        /// <param name="when">交易日期。</param>
        /// <param name="amount">交易金额。</param>
        public Transaction(string who, Date when, double amount)
        {
            if (double.IsNaN(amount) || double.IsInfinity(amount))
            {
                throw new ArgumentException("Amount cannot be NaN or Infinity");
            }
            this.Who = who;
            this.When = when;
            this.Amount = amount;
        }

        /// <summary>
        /// 从标准输入中按行读取所有交易信息，返回一个 Transaction 数组。
        /// </summary>
        /// <returns></returns>
        public static Transaction[] ReadTransactions()
        {
            char[] split = new char[] { '\n' };
            string[] input = Console.In.ReadToEnd().Split(split, StringSplitOptions.RemoveEmptyEntries);
            Transaction[] t = new Transaction[input.Length];

            for (int i = 0; i < input.Length; ++i)
            {
                t[i] = new Transaction(input[i]);
            }

            return t;
        }

        /// <summary>
        /// 返回字符串形式的交易信息。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0, -10} {1, 10} {2, 8:F2}", this.Who, this.When, this.Amount);
        }

        /// <summary>
        /// 默认按照交易金额升序比较。
        /// </summary>
        /// <param name="other">比较的另一个对象。</param>
        /// <returns></returns>
        public int CompareTo(Transaction other)
        {
            if (this.Amount < other.Amount)
                return -1;
            if (this.Amount > other.Amount)
                return 1;
            return 0;
        }

        /// <summary>
        /// 按照客户姓名升序比较。
        /// </summary>
        public class WhoOrder : IComparer<Transaction>
        {
            int IComparer<Transaction>.Compare(Transaction x, Transaction y)
            {
                return x.Who.CompareTo(y.Who);
            }
        }

        /// <summary>
        /// 按照交易时间升序比较。
        /// </summary>
        public class WhenOrder : IComparer<Transaction>
        {
            int IComparer<Transaction>.Compare(Transaction x, Transaction y)
            {
                return x.When.CompareTo(y.When);
            }
        }

        /// <summary>
        /// 按照交易金额升序比较。
        /// </summary>
        public class HowMuchOrder : IComparer<Transaction>
        {
            int IComparer<Transaction>.Compare(Transaction x, Transaction y)
            {
                return x.Amount.CompareTo(y.Amount);
            }
        }

        /// <summary>
        /// 比较两笔交易是否相同。
        /// </summary>
        /// <param name="obj">另一个对象。</param>
        /// <returns></returns>
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
                (that.When.Equals(this.When)) &&
                (that.Who == this.Who);
        }

        /// <summary>
        /// 返回交易信息的哈希值。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 1;
            hash = 31 * hash + this.Who.GetHashCode();
            hash = 31 * hash + this.When.GetHashCode();
            hash = 31 * hash + this.Amount.GetHashCode();
            return hash;
        }
    }
}
