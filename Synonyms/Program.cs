using System;
using System.Diagnostics;

namespace Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSynonyms.Run();

            Synonyms synonyms = new Synonyms();
            string line;

            while ((line = Console.ReadLine()) != null)
            {
                string[] command = line.Split();
                switch (command[0].ToUpper())
                {
                    case "ADD":
                        synonyms.Add(command[1], command[2]);
                        break;

                    case "COUNT":
                        Console.WriteLine(synonyms.GetSynonymCount(command[1]));
                        break;

                    case "CHECK":
                        Console.WriteLine(synonyms.AreSynonyms(command[1], command[2]) ? "YES" : "NO");
                        break;

                    case "EXIT":
                        return;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
