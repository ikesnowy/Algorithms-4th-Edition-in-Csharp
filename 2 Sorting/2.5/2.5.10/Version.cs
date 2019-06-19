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
            versionNumber = new int[versions.Length];
            for (var i = 0; i < versions.Length; i++)
            {
                versionNumber[i] = int.Parse(versions[i]);
            }
        }

        public int CompareTo(Version other)
        {
            for (var i = 0; i < versionNumber.Length && i < other.versionNumber.Length; i++)
            {
                if (versionNumber[i].CompareTo(other.versionNumber[i]) != 0)
                    return versionNumber[i].CompareTo(other.versionNumber[i]);
            }
            return versionNumber.Length.CompareTo(other.versionNumber.Length);
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < versionNumber.Length - 1; i++)
            {
                result += versionNumber[i] + ".";
            }
            result += versionNumber[versionNumber.Length - 1].ToString();
            return result;
        }
    }
}
