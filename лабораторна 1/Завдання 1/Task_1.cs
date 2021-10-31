using System;
using static System.Console;
using static System.Math;

namespace _1task
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z, a, b;
            Write("x = "); x = double.Parse(ReadLine());
            Write("y = "); y = double.Parse(ReadLine());
            Write("z = "); z = double.Parse(ReadLine());

            if (x == 0 || y == 0 || z == 0)
            {
                WriteLine("помилка");
            }
            else
            {
                a = Cos(x + (x * y / z));
                b = Pow(x, 3) / Cos(a);

                WriteLine("a = " + a);
                WriteLine("b = " + b);
            }
            ReadKey();
        }
    }
}
