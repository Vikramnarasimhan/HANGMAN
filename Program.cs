using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace gameapp
{
    class Program
    {
        public enum Gamestatus { 
        Gamestarted,
        Playerwon,
        PlayerLost

        
        }
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
            Console.WriteLine($"{wordtoplay.Length}");
            Console.WriteLine("Enter your name");
            string userinput=Console.ReadLine();
            Comparingoperation( wordtoplay,userinput);

            static void Comparingoperation(string target,string name)
            {
                Console.WriteLine("WELCOME TO HANGMAN LETS BEGIN!!");
                char[] revealed = new string('_', target.Length).ToCharArray();
                int chances = 3;
                while (chances > 0 && new string(revealed) != target) {
                    Console.WriteLine($"CHANCES LEFT:{chances}");
                    Console.WriteLine($"WORD:{string.Join(" ",revealed)}");
                    Console.WriteLine("ENTER A GUESS CHARACTER");
                    string guessread=Console.ReadLine();
                    if (string.IsNullOrEmpty(guessread)) continue;

                    char guess = guessread[0];
                    bool correct = false;
                    for (int i = 0; i < target.Length; i++)
                    {
                        if (guess == char.ToLower(target[i]) && revealed[i] == '_')
                        {
                            revealed[i] = target[i];
                            correct = true;
                        }
                    }
                    if (correct)
                    {
                        chances = 3;
                        Console.WriteLine("CORRECT GUESS CHANCES RESET TO 3");
                    }
                    else {
                        chances--;
                        Console.WriteLine($"Got it wrong only {chances} left ");
                    
                    
                    }
               

                  

                }
                if (new string(revealed) == target)
                {
                   // status = Gamestatus.Playerwon;

                    Console.WriteLine($"{name} you got it right time to move to next level");
                }
                else {
                   // status = Gamestatus.PlayerLost;
                    Console.WriteLine($"{name} you lost it try again");
                }




            }






        }
    }
}
