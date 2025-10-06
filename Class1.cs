using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace gameapp
{
    class Program
    {
        public enum Gamestatus
        {
            Gamestarted,
            Playerwon,
            PlayerLost


        }
        static void Main(string[] args)
        {
            string filepath = "wordx.csv";
            //List<string> words = new List<string>();
            Console.WriteLine("I am trying to read csv data in my csharp");
            List<(string word, string clue)> wordCluePairs = new List<(string, string)>();

            foreach (var line in File.ReadLines(filepath))
            {
                string[] values = line.Split(',');
                if (values.Length == 2)
                {
                    wordCluePairs.Add((values[0].Trim(), values[1].Trim()));
                }
            }
            Random rand = new Random();

            int randomIndex = rand.Next(wordCluePairs.Count);
            string wordtoplay = wordCluePairs[randomIndex].word;
            string clue = wordCluePairs[randomIndex].clue;

            //Console.WriteLine($"Random word:{wordtoplay}");
            Console.WriteLine($"Clue:{clue}");
            Console.WriteLine("Enter your name");
            string userinput = Console.ReadLine();
            Comparingoperation(wordtoplay, userinput);

            static void Comparingoperation(string target, string name)
            {
                string[] hangmanStages = new string[]
{


    @"                                    
                                    
                                    
                                    
                                    
                                    
                                    
                                    
                                    
                                    
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
                                    
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
                                    
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
               ░██                  
                                    
                                    
                                    
            ░██████ ░██████ ░██████ 
                                    
            ░██████ ░██████ ░██████ 
                                    
                                    
                                    
                                    
                                    ",

    @"      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
                           
      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
      ░██                  
                           
        ░██████            
       ░██   ░██           
      ░██     ░██          
      ░██     ░██          
      ░██     ░██          
       ░██   ░██           
        ░██████            
                           
                           
                           
                           
                           
   ░██████ ░██████ ░██████ 
                           
   ░██████ ░██████ ░██████ 
                           
                           
                           
                           
                           ",

    @"   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
                        
   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
   ░██                  
                        
     ░██████            
    ░██   ░██           
   ░██     ░██          
   ░██     ░██          
   ░██     ░██          
    ░██   ░██           
     ░██████            
                        
                        
                        
      ░██ ░██ ░██       
     ░██  ░██  ░██      
    ░██   ░██   ░██     
   ░██    ░██    ░██    
  ░██     ░██     ░██   
 ░██      ░██      ░██  
░██       ░██       ░██ 
          ░██           
          ░██           
                        
      ░██    ░██        
     ░██      ░██       
    ░██        ░██      
   ░██          ░██     
  ░██            ░██    
 ░██              ░██   
░██                ░██  
                        
                        
                        
                        
                        
░██████ ░██████ ░██████ 
                        
░██████ ░██████ ░██████ 
                        
                        
                        
                        
                        "
    
};

                Console.WriteLine("WELCOME TO HANGMAN LETS BEGIN!!");
                char[] revealed = new string('_', target.Length).ToCharArray();
                int chances = 3;
                int hangerdiagram = 0;
                while (chances > 0 && new string(revealed) != target)
                {
                    Console.WriteLine($"CHANCES LEFT:{chances}");
                    Console.WriteLine($"WORD:{string.Join(" ", revealed)}");
                    //Console.WriteLine(hangmanStages[]);
                    Console.WriteLine("ENTER A GUESS CHARACTER");
                    string guessread = Console.ReadLine();
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
                        hangerdiagram = 0;
                    }
                    else
                    {
                        chances--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Got it wrong only {chances} left ");
                        Console.WriteLine(hangmanStages[hangerdiagram]);
                        hangerdiagram++;
                        Console.ResetColor();

                    }




                }
                if (new string(revealed) == target)
                {
                    // status = Gamestatus.Playerwon;
                    Console.ForegroundColor = ConsoleColor.Green;
                    string successart = @"   ░██████   ░██     ░██   ░██████    ░██████  ░██████████   ░██████     ░██████   
 ░██   ░██  ░██     ░██  ░██   ░██  ░██   ░██ ░██          ░██   ░██   ░██   ░██  
░██         ░██     ░██ ░██        ░██        ░██         ░██         ░██         
 ░████████  ░██     ░██ ░██        ░██        ░█████████   ░████████   ░████████  
        ░██ ░██     ░██ ░██        ░██        ░██                 ░██         ░██ 
 ░██   ░██   ░██   ░██   ░██   ░██  ░██   ░██ ░██          ░██   ░██   ░██   ░██  
  ░██████     ░██████     ░██████    ░██████  ░██████████   ░██████     ░██████   
                                                                                  
                                                                                  
                                                                                  ";

                    Console.WriteLine(successart);
                    Console.WriteLine($"{ name} you got it right time to move to next level");
                    Console.ResetColor();
                }
                else
                {
                    // status = Gamestatus.PlayerLost;
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"{name} you lost it try again");
                    Console.ResetColor();
                }




            }






        }
    }
}
