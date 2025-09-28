using System;
namespace lab4_4
{
    internal class Program
    {
        public static double f(double x)
        {
            return x * x - 4;
        }

        static void Bisection(double a, double b, double Eps)
        {
            double c;
            int Lich = 0;

            if (f(a) * f(b) > 0)
            {
                Console.WriteLine("No root in the interval.");
                return;
            }

            while (Math.Abs(b - a) > Eps)
            {
                c = 0.5 * (a + b);
                Lich++;

                if (Math.Abs(f(c)) < Eps)
                {
                    Console.WriteLine($"Root ≈ {c}, iterations = {Lich}");
                    return;
                }
                else if (f(a) * f(c) < 0) b = c;
                else a = c;
            }

            Console.WriteLine($"Root ≈ {(a + b) / 2}, iterations = {Lich}");
        }

        static bool FindInterval(double Xmin, double Xmax, double h, out double a, out double b)
        {
            a = b = 0;

            double x1 = Xmin;
            double f1 = f(x1);

            for (double x2 = Xmin + h; x2 <= Xmax; x2 += h)
            {
                double f2 = f(x2);

                if (f1 * f2 <= 0) 
                {
                    a = x1;
                    b = x2;
                    return true;
                }

                x1 = x2;
                f1 = f2;
            }

            return false; 
        }

        static void Main(string[] args)
        {
            double Eps;
            Console.Write("Input Eps: ");
            Eps = Convert.ToDouble(Console.ReadLine());

            double Xmin = -100, Xmax = 100, h = 1.0;

            if (FindInterval(Xmin, Xmax, h, out double a, out double b))
            {
                Console.WriteLine($"Interval found: [{a}, {b}]");
                Bisection(a, b, Eps);
            }
            else
            {
                Console.WriteLine("No interval with root found in given range.");
            }

            Console.ReadLine();
        }
    }
}
