using System;
namespace lab4_3
{
    internal class Program
    {
        static double f(double x)
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
                Console.ReadLine();
                return;
            }

            if (Math.Abs(f(a)) < Eps)
            {
                Console.WriteLine($"x = {a}, iterations = {Lich}");
                Console.ReadLine();
                return;
            }
            if (Math.Abs(f(b)) < Eps)
            {
                Console.WriteLine($"x = {b}, iterations = {Lich}");
                Console.ReadLine();
                return;
            }

            while (Math.Abs(b - a) > Eps)
            {
                c = 0.5 * (a + b);
                Lich++;

                if (Math.Abs(f(c)) < Eps)
                {
                    Console.WriteLine($"x = {c}, iterations = {Lich}");
                    Console.ReadLine();
                    return;
                }
                else if (f(a) * f(c) < 0) b = c;
                else a = c;
            }

            Console.WriteLine($"x = {(a + b) / 2}, iterations = {Lich}");
            Console.ReadLine();
        }

        static double fp(double x, double D)
        {
            return (f(x + D) - f(x)) / D;
        }

        static double f2p(double x, double D)
        {
            return (f(x + D) + f(x - D) - 2 * f(x)) / (D * D);
        }

        static void Newton(double a, double b, double Eps, int Kmax)
        {
            double x, D, Dx;
            int i;

            D = Eps / 100.0;
            x = b;

            if (f(x) * f2p(x, D) < 0)
            {
                x = a;
            }
            else if (f(x) * f2p(x, D) == 0)
            {
                Console.WriteLine("For a given equation, the convergence of Newton's method is not guaranteed.");
                Console.ReadLine();
                return;
            }

            for (i = 1; i <= Kmax; i++)
            {
                Dx = f(x) / fp(x, D);
                x = x - Dx;

                if (Math.Abs(Dx) <= Eps)
                {
                    Console.WriteLine($"The root ≈ {x}, found in {i} iterations.");
                    Console.ReadLine();
                    return;
                }
            }

            Console.WriteLine("For the given number of iterations, the root with accuracy Eps was not found.");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                double a, b, Eps;
                int Kmax;

                Console.WriteLine("Input a, b, eps:");
                a = Convert.ToDouble(Console.ReadLine());
                b = Convert.ToDouble(Console.ReadLine());
                Eps = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Choose method: 1 - Bisection, 2 - Newton");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    Bisection(a, b, Eps);
                else if (choice == 2)
                {
                    Console.Write("Enter the maximum allowed number of iterations Kmax: ");
                    Kmax = int.Parse(Console.ReadLine());
                    Newton(a, b, Eps, Kmax);
                }
                else
                    Console.WriteLine("Invalid choice.");

                Console.WriteLine("Do you want to continue? (y/n)");
                string answer = Console.ReadLine();

                if (answer.ToLower() != "y")
                {
                    Console.WriteLine("Program terminated.");
                    break; 
                }
                Console.Clear(); 
            }
        }
    }
}
