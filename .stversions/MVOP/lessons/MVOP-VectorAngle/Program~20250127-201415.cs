using System;
using System.IO;
using System.Collections.Generic;

namespace uhelvekturu
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int i = 0;
                double[] temp = new double[2];
                List<Vector> vectors = new List<Vector> { };
                foreach (string item in File.ReadAllText("C:/Users/kubin.kr.2021/Documents/file.csv").Replace("\n", ",").Split(","))
                {
                    temp[i] = double.tryParse(item.Replace(".", ","));
                    System.Console.WriteLine(item);
                    i = (i + 1) % 2;
                    if (i == 0)
                    {
                        vectors.Add(new Vector(temp[0], temp[1]));
                    }
                }
                foreach (var item in vectors)
                {
                    Console.WriteLine(item.ToString());
                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Soubor neobsahuje data");
            }

        }


    }

    class Vector
    {
        public double X;
        public double Y;

        public Vector(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public string ToString()
        {
            return $"({this.X},{this.Y})";
        }
    }
}
