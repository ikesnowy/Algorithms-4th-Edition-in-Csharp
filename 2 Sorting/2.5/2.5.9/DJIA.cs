using System;

// ReSharper disable IdentifierTypo

namespace _2._5._9;

/// <summary>
/// 道琼斯指数。
/// </summary>
internal class Djia : IComparable<Djia>
{
    public string Date { get; set; }
    public long Volume { get; set; }

    public Djia(string date, long vol)
    {
        Date = date;
        Volume = vol;
    }

    public int CompareTo(Djia? other)
    {
        if (other == null)
        {
            return -1;
        }

        return Volume.CompareTo(other.Volume);
    }
}