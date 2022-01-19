using System;
using static System.Console;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            long[,] A;
            int N, M;
            long K;
            Random rnd = new Random();
            Write("K = "); K = Convert.ToInt32(ReadLine());
            Write("N = "); N = Convert.ToInt32(ReadLine());
            Write("M = "); M = Convert.ToInt32(ReadLine());
            A = new long[N, M];
            for (long i = 0; i < N; i++)
            {
                for (long j = 0; j < M; j++)
                {
                    A[i, j] = rnd.Next(1, 100);
                }
            }
            WriteLine("Created:");
            Print(A, K);
            Sort(A, K);
            WriteLine("Sorted:");
            Print(A, K);
            ReadLine();
        }

        static void Print(long[,] A, long K)
        {
            long N = A.GetLength(0);
            long M = A.GetLength(1);

            for (long i = 0; i < N; i++)
            {
                for (long j = 0; j < M; j++)
                {
                    long m = A[i, j];
                    if (Check(j, K))
                    {
                        ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                    Write(m + "\t");
                }
                WriteLine();
            }
            ForegroundColor = ConsoleColor.White;
        }

        static void Sort(long[,] A, long K)
        {
            long N = A.GetLength(0);
            long M = A.GetLength(1);
            (long c, long f) = GetColumnInterval(A, K);
            long i, j, q, z, a, b, t;
            q = 0;
            z = f;
            while (Less(N - 1, c, q, z))
            {
                i = N - 1;
                j = c;
                while (Less(i, j, q, z))
                {
                    (a, b) = Next(i, j, A, K);
                    if (A[i, j] > A[a, b])
                    {
                        t = A[i, j];
                        A[i, j] = A[a, b];
                        A[a, b] = t;
                    }
                    i = a;
                    j = b;
                }
                (q, z) = Prev(q, z, A, K);
            }
        }

        static (long, long) GetColumnInterval(long[,] A, long K)
        {
            long p, t;
            long M = A.GetLength(1);
            for (p = 0; p < M && !Check(p, K); p++) ;
            for (t = M - 1; t >= 0 && !Check(t, K); t--) ;
            return (p, t);
        }
        static (long, long) Next(long i, long j, long[,] A, long K)
        {
            long N = A.GetLength(0);
            long M = A.GetLength(1);
            if (i > 0) return (i - 1, j);
            long x;
            for (x = j + 1; (x < M) && !Check(x, K); x++) ;
            return (N - 1, x);
        }

        static (long, long) Prev(long i, long j, long[,] A, long K)
        {
            long N = A.GetLength(0);
            long M = A.GetLength(1);
            if (i < N - 1) return (i + 1, j);
            long x;
            for (x = j - 1; (x >= 0) && !Check(x, K); x--) ;
            return (0, x);
        }

        static Boolean Less(long i1, long j1, long i2, long j2)
        {
            return (j1 < j2) || (j1 == j2 && i1 > i2);
        }

        static Boolean Check(long j, long K)
        {
            return Nsk(j + 1, K) % 2 == 1;
        }

        static long Nsd(long k, long t)
        {
            long x;
            if (k < t)
            {
                x = t;
                t = k;
                k = x;
            }
            do
            {
                x = k % t;
                k = t;
                t = x;
            } while (t != 0);
            return k;
        }

        static long Nsk(long k, long t)
        {
            return k * t / Nsd(k, t);
        }
    }
}