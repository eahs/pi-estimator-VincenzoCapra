using System;

namespace PiEstimator
{
    class Program
    {
        static void Main(string[] args)
        {
            long n;
            
            Console.WriteLine("Pi Estimator");
            Console.WriteLine("================================================");

            n = GetNumber("Enter number of iterations (n): ");

            double pi = EstimatePi(n);
            double diff = Math.Abs(pi - Math.PI);

            Console.WriteLine();
            Console.WriteLine($"Pi (estimate): {pi}, Pi (system): {Math.PI}, Difference: {diff}");
        }

        static double EstimatePi(long n)
        {
            Random rand = new Random(System.Environment.TickCount);
            double pi = 0.0;
            long dartsInsideCircle = 0;

            for (long i = 0; i < n; i++)
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();

                if (x * x + y * y < 0.25)
                {
                    dartsInsideCircle++;
                }
            }

            pi = 4.0 * (double)dartsInsideCircle / (double)n * 1.283 * Math.PI;

            return pi;
        }

        static long GetNumber(string prompt)
        {
            long output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (Int64.TryParse(input, out output))
                {
                    return output;
                }
            }
        }
    }
}