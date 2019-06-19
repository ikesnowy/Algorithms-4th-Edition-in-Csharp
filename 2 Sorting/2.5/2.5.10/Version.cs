using System;

namespace _2._5._10
{
    /// <summary>
    /// 版本号。
    /// </summary>
    class Version : IComparable<Version>
    {
        private int[] versionNumber;

        public Version(string version)
        {
            var versions = version.Split('.');
            this.versionNumber = new int[versions.Length];
            for (var i = 0; i < versions.Length; i++)
            {
                this.versionNumber[i] = int.Parse(versions[i]);
            }
        }

        public int CompareTo(Version other)
        {
            for (var i = 0; i < this.versionNumber.Length && i < other.versionNumber.Length; i++)
            {
                if (this.versionNumber[i].CompareTo(other.versionNumber[i]) != 0)
                    return this.versionNumber[i].CompareTo(other.versionNumber[i]);
            }
            return this.versionNumber.Length.CompareTo(other.versionNumber.Length);
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < this.versionNumber.Length - 1; i++)
            {
                result += this.versionNumber[i] + ".";
            }
            result += this.versionNumber[this.versionNumber.Length - 1].ToString();
            return result;
        }
    }
}
