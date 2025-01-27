using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace string_4
{
  class Program
  {
    static void Main(string[] args)
    {
      Regex anyWord = new Regex(@"[^\.\,\ ]+");
      Dictionary<string, List<int>> wordPostions = new Dictionary<string, List<int>>();

      string filePath = "text.txt";
      StringBuilder text = new StringBuilder(File.ReadAllText(filePath, Encoding.UTF8));
      List<StringBuilder> registry = new List<StringBuilder>();

      string word = " ";
      int numberOfOcurences = 0;

      registry = registryGenerator();

      File.AppendAllText(filePath, "\n\n\n");

      foreach (StringBuilder item in registry)
      {
        if (item.ToString() != "")
        {
          File.AppendAllText(filePath, item.ToString());
        }
      }


      List<StringBuilder> registryGenerator()
      {
        List<StringBuilder> registry = new List<StringBuilder>();
        StringBuilder tempText = new StringBuilder(text.ToString());

        int i = 0;
        while (anyWord.Match(tempText.ToString()).Success && i < 1000)
        {
          word = anyWord.Match(tempText.ToString()).Value;
          tempText = tempText.Replace(word, "");

          numberOfOcurences = (new Regex(word)).Matches(text.ToString()).Count;
          wordPostions.Add(word, new List<int>());

          foreach (Match match in (new Regex(word)).Matches(text.ToString()))
          {
            wordPostions[word].Add(match.Index);
          }

          if (wordPostions[word].Count != 0)
          {
            registry.Add(registryLineGenerator());
          }

          i++;
        }

        return registry;

        StringBuilder registryLineGenerator()
        {
          StringBuilder registryLine = new StringBuilder();
          if (wordPostions.TryGetValue(word, out List<int> intList))
          {
            registryLine.Append(' ', 15);
            foreach (int item in intList)
            {
              registryLine.Append($"{item}, ");
            }
            registryLine.Remove(0, word.Length);
            registryLine.Insert(0, word);
            registryLine.Append("\n");
          }


          return registryLine;
        }
      }

    }
  }
}
