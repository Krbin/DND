
using System.Net.Http.Headers;

double numberOfDice = 7;

double numberOfSides = 2;

double numberOfThrows = 100;

Console.WriteLine(Math.Pow(1 / numberOfSides, numberOfDice) * (numberOfThrows - numberOfDice));


