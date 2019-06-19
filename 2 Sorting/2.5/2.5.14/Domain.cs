using System;
using System.Text;

namespace _2._5._14
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
            fields = url.Split('.');
            n = fields.Length;
        }

        public int CompareTo(Domain other)
        {
            var minLength = Math.Min(n, other.n);
            for (var i = 0; i < minLength; i++)
            {
                var c = fields[minLength - i - 1].CompareTo(other.fields[minLength - i - 1]);
                if (c != 0)
                    return c;
            }

            return n.CompareTo(other.n);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < fields.Length; i++)
            {
                if (i != 0)
                    sb.Append('.');
                sb.Append(fields[i]);
            }
            return sb.ToString();
        }
    }
}
