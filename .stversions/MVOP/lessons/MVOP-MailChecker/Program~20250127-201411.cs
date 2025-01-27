using System;
using System.Text.RegularExpressions;


namespace MailChecker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex emailRegex = new Regex(@"[A-Za-z0-9]+[\._]?[A-Za-z0-9]+\@([A-Za-z])\.cz");
            string emails =
                @"
                jan.novak@seznam.cz
                jannovak@mail.cz
                jan_novak111@centrum.cz";
            foreach (var item in emailRegex.Matches(emails))
            {
                Console.WriteLine($"{item}");

            }
        }
    }
}