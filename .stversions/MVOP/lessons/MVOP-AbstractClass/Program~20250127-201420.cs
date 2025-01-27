using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace _20_11_2023
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle[] circles = new Circle[] { new Circle(1, 1, 1),
            new Circle(2, 2, 10), new Circle(3, 4, 5),
            new Circle(10, 9, 8), Circle.ConsoleConstruct() };

            Circle c = circles[0];
            foreach (Circle item in circles)
            {
                Console.WriteLine($"{item.ToString()}\n" + (item.Intersects(c) ? "" : "ne") + $"protíná\n {c.ToString()}\n");
                c = item;
            }

        }
    }


    abstract class GeometricObject
    {
        public double X;
        public double Y;
        private static int identifier;
        private int uniqueIdentifier;
        public int UniqueIdentifier
        {
            get { return uniqueIdentifier; }
        }

        public GeometricObject(double X, double Y) : this()
        {
            this.X = X;
            this.Y = Y;
        }
        public GeometricObject()
        {
            this.uniqueIdentifier = identifier;
            identifier++;

        }

        public double MomentX()
        {
            return this.Y * this.Area();
        }

        public abstract double Perimeter();

        public abstract double Area();


    }

    class Circle : GeometricObject
    {
        public double Radius = 0;

        public Circle(double Radius, double X, double Y) : base(X, Y)
        {
            this.Radius = Radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }


        public bool Intersects(Circle circle)
        {
            return Math.Sqrt(Math.Abs(this.X - circle.X) + Math.Abs(this.Y - circle.Y)) < this.Radius + circle.Radius;
        }

        public string ToString()
        {
            return $"Kruh na souřadnicích {X} {Y} a s poloměrem {Radius}\nObvod je {this.Perimeter()}\nObsah je {this.Area()}";
        }


        public static Circle ConsoleConstruct()
        {
            double x = 0;
            double y = 0;
            double radius = 0;

            bool loop = true;
            int inputNumber = 0;


            while (loop)
            {
                switch (inputNumber)
                {
                    case 0:
                        Console.Write($"\nSouřadnice X: ");
                        if (!double.TryParse(Console.ReadLine(), out x))
                        {
                            continue;
                        }
                        inputNumber = 1;
                        break;
                    case 1:
                        Console.Write($"\nSouřadnice Y: ");
                        if (!double.TryParse(Console.ReadLine(), out y))
                        {
                            continue;
                        }
                        inputNumber = 2;
                        break;
                    case 2:
                        Console.Write($"\nRadius: ");
                        if (!double.TryParse(Console.ReadLine(), out radius))
                        {
                            continue;
                        }
                        inputNumber = 3;
                        break;
                    default:
                        loop = false;
                        break;
                }


            }


            return new Circle(radius, x, y);

        }
    }
    class Square : GeometricObject
    {
        public double Side = 0;

        public Square(double Side, double X, double Y) : base(X, Y)
        {
            this.Side = Side;
        }
        public override double Perimeter()
        {
            return 4 * Side;
        }
        public override double Area()
        {
            return Side * Side;
        }
    }
}
