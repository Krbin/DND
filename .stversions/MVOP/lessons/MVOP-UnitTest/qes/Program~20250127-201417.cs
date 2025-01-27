using System;
namespace Qes
{
    public class qes
    {
        static void Main(string[] args) { }

        public static double Discriminator(double a, double b, double c)
        {
            double discriminator = Math.Pow(b, 2) - 4 * a * c;
            if (discriminator < 0)
            {
                throw new DiscriminatorLowerThanZero("Denominator is lower than 0");
            }

            return discriminator;
        }
        public static double Qes(double a, double b, double c)
        {
            double result;
            double discriminator = Discriminator(a, b, c);

            result = (-b + Math.Sqrt(discriminator)) / (2 * a);

            if (result < 0)
            {
                result = (-b - Math.Sqrt(discriminator)) / (2 * a);
            }


            return result;
        }
    }
public class DiscriminatorLowerThanZero : Exception
{
public DiscriminatorLowerThanZero() { }
public DiscriminatorLowerThanZero(string message): base(message) { }
}



}
