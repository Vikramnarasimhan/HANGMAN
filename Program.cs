using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace gameapp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "words.csv";
            List<string> words = new List<string>();
            Console.WriteLine("I am trying to read csv data in my csharp");
            foreach (var line in File.ReadLines(filepath))
            {
                string[] values = line.Split('.');
                if (values.Length > 1)
                {
                    words.Add(values[1]);
                }
               
            }
            string[] wordarray= words.ToArray();
            Random rand = new Random();
            int randominmyarray = rand.Next(wordarray.Length);
            string wordtoplay=wordarray[randominmyarray];
            Console.WriteLine($"Random word:{wordtoplay}");
        }
    }
}
