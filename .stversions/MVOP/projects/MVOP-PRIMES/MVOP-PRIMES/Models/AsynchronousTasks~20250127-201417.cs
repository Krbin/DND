using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVOP_PRIMES.Models;

namespace MVOP_PRIMES.Models
{
    public class AsynchronousPrimeTasks
    {
        string path = "Z:/primes.txt";
        public async Task<int?> FirstPrimeWithXAmountOfY(int x, int y)
        {
            int? result = 0;
            string? line = "";
            bool success = false;
            await Task.Run(() =>
            {
                StreamReader stream = new StreamReader(path);
                line = stream.ReadLine();

                if (line != null)
                {
                    if (line.Length >= x)
                    {
                        while (!success)
                        {

                        }
                    }

                }

            });

            return result;
        }

        public async Task<int> MethodB()
        {
            int result = 0;
            await Task.Run(() =>
            {

            });

            return result;
        }

        public async Task<int> MethodC()
        {
            int result = 0;
            await Task.Run(() =>
            {

            });

            return result;
        }
    }
}
