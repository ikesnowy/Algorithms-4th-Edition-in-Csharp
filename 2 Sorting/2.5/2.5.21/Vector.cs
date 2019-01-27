using System;
using System.Text;

namespace _2._5._21
{
    class Vector : IComparable<Vector>
    {
        private int[] data;
        public int Length { get; set; }

        public Vector(int[] data)
        {
            this.data = data;
            this.Length = data.Length;
        }

        public int CompareTo(Vector other)
        {
            int maxN = Math.Max(this.Length, other.Length);
            for (int i = 0; i < maxN; i++)
            {
                int comp = this.data[i].CompareTo(other.data[i]);
                if (comp != 0)
                    return comp;
            }
            return this.Length.CompareTo(other.Length);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Length; i++)
            {
                if (i != 0)
                    sb.Append(' ');
                sb.Append(this.data[i]);
            }
            return sb.ToString();
        }
    }
}
