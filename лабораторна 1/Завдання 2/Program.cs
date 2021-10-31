using System;
using static System.Console;
using static System.Math;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            long n;
            bool Mersen_flag;
            long i, j;
            n = 1000000;

            for (i = 2; i < n; i++)  // перевірка чисел 
            {
                bool flag_Prime = true;
                for (j = 2; j <= Sqrt(i); j++)
                    if (i % j == 0)
                    {
                        flag_Prime = !flag_Prime;
                        break;
                    }
                if (flag_Prime)
                {
                    double p_log = Log(i + 1, 2);
                    bool long_Log = Abs(Round(p_log) - p_log) < 1.0E-8;
                    if (long_Log)
                    {
                        long P = (long)Round(p_log);
                        Mersen_flag = true;
                        for (j = 2; j <= Sqrt(P); j++)
                            if (P % j == 0)
                            {
                                Mersen_flag = !Mersen_flag;
                                break;
                            }
                        if (Mersen_flag)
                            WriteLine("2^" + P.ToString() + "-1 = " + i.ToString());
                    }
                }
            }
        }
    }
}
