using System;
using System.Text;

namespace _2._5._15
{
    /// <summary>
    /// 域名类。
    /// </summary>
    class Domain : IComparable<Domain>
    {
        private string[] fields;
        private int n;

        /// <summary>
        /// 构造一个域名。
        /// </summary>
        /// <param name="url">域名的 url。</param>
        public Domain(string url)
        {
            this.fields = url.Split('.');
            this.n = this.fields.Length;
        }

        public int CompareTo(Domain other)
        {
            int minLength = Math.Min(this.n, other.n);
            for (int i = 0; i < minLength; i++)
            {
                int c = this.fields[minLength - i - 1].CompareTo(other.fields[minLength - i - 1]);
                if (c != 0)
                    return c;
            }

            return this.n.CompareTo(other.n);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.fields.Length; i++)
            {
                if (i != 0)
                    sb.Append('.');
                sb.Append(this.fields[i]);
            }
            return sb.ToString();
        }
    }
}
