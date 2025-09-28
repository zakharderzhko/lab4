using System;
namespace lab4_2
{
    class Program
    {
        static double f(double x)
        {
            return x * x - 4;
        }

        static double fp(double x, double D)
        {
            return (f(x + D) - f(x)) / D;
        }

        static double f2p(double x, double D)
        {
            return (f(x + D) + f(x - D) - 2 * f(x)) / (D * D);
        }

        static void Main(string[] args)
        {
            double a, b; 
            double Eps;   
            double x, D, Dx;  

            int i;    
            int Kmax;  

            Console.WriteLine(" Input a, b, eps");
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            Eps = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the maximum allowed number of iterations Kmax: ");
            Kmax = int.Parse(Console.ReadLine());

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
                    Console.WriteLine($"The root of the equation ≈ {x}, found in {i} iterations.");
                    Console.ReadLine();
                    return;
                }
            }

            Console.WriteLine("For the given number of iterations, the root with accuracy Eps was not found.");
            Console.ReadLine();
        }
    }
}
