namespace _1._2._17
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Rational(long.MaxValue, 1);
            var b = new Rational(1, 1);
            var c = a.Plus(b);
        }
    }
}
