namespace _1._2._17
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Rational a = new Rational(long.MaxValue, 1);
            Rational b = new Rational(1, 1);
            Rational c = a.Plus(b);
        }
    }
}
