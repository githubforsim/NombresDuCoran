using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var fzResult = Tools.FindWordInLine("Lion", "FreLion est Lion ou pas un Liond Lion");
            //ConvertOriginalFile();
            //return;

            var chants = GetChants();
            CreatePages(chants);
            return;

            var word = "Akhilleus";
            var total = 0;
            for (int i = 0; i < chants.Length; i++)
            {
                var chant = chants[i];
                var result = Tools.FindLinesOfWord(chant._lignes, word);
                total += result.Length;
                Console.WriteLine("Chant " + (i+1) + " : " + result.Length);
            }

            Console.WriteLine("\nTotal = " + total);

            Console.WriteLine("\n\nPress a key ...");
            Console.ReadKey();
        }

        private static Chant[] GetChants()
        {
            var lines = File.ReadAllLines("Iliade.txt");
            var chantsAsLists = new List<List<string>>();
            {
                List<string> chant = null;
                foreach (var line in lines)
                {
                    if (line.StartsWith("Chant ") && 
                        (line.Length == "Chant X".Length || line.Length == "Chant XX".Length)
                        )
                    {
                        chantsAsLists.Add(chant = new List<string>());
                    }

                    chant.Add(line);
                }
            }

            //for (int i = 0; i < chants.Count; i++)
            //{
            //    var chant = chants[i];
            //    File.WriteAllLines("Chant_" + (i + 1) + ".txt", chant);
            //}

            var output = new List<Chant>();
            for (int i = 0; i < chantsAsLists.Count; i++)
            {
                var chant = new Chant(chantsAsLists[i].ToArray());
                output.Add(chant);
            }

            return output.ToArray();
        }

        private static void CreatePages(Chant[] chants)
        {
            int idPage = 1;
            for (int idChant = 1; idChant <= chants.Length; idChant++) 
            {
                Chant chant = chants[idChant-1];
                for (int i = 1; i <= chant.NbPages; i++) 
                {
                    File.WriteAllLines("Pages/Page_" + idPage + " - Chant " + idChant + ".txt", chant.GetLinesOfPage(i));
                    idPage++;
                }
            }
        }

        private static void ConvertOriginalFile()
        {
            var originalLines = File.ReadAllLines("Iliade_original.txt");
            var lines = new List<string>();
            foreach (var originalLine in originalLines)
            {
                if (originalLine == "")
                {
                    bool t = true;
                    continue;
                }

                var result = originalLine.WordWrap(80);

                lines.AddRange(result);
            }

            File.WriteAllLines("Iliade.txt", lines);
        }
    }
}
