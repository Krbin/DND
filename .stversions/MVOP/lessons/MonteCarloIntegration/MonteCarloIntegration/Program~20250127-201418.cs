

namespace Program
{
    public static class MonteCarloIntegration
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MonteCarloIntegrate(toThird, 2, 3, 100, 1000000000));

        }

        public static double MonteCarloIntegrate(Func<double, double> fx, double start, double end, double maxValue ,int iterations)
        {

            double area = Math.Abs((start - end) * maxValue);

            double guessX;
            double guessY;

            double sum = 0;

            Random rnd = new Random();

            for (int j = 0; j < iterations; j++)
            {
                guessX = start + rnd.NextDouble() * (end - start);
                guessY = 0 + rnd.NextDouble() * (maxValue - 0);

                if (guessY < fx(guessX))
                {
                    sum++;
                }

                

            }

            return sum / iterations * area;
        }
        public static double toThird(double x)
        {
            return Math.Pow(x, 3);
        }

    }
}