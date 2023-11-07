using System.Collections.Generic;

namespace ConsoleApp
{
    public static class Tools
    {
        public static string[] WordWrap(this string self, int maxLength)
        {
            var output = new List<string>();
            var source = self;
            while (source.Length > 0)
            {
                if (source.Length <= maxLength)
                {
                    output.Add(source);
                    break;
                }

                for (int i = maxLength; i >= 0; i--)
                {
                    var c = source[i];
                    if (char.IsWhiteSpace(c))
                    {
                        output.Add(source.Substring(0, i));
                        source = source.Substring(i + 1);
                        break;
                    }
                }
            }

            return output.ToArray();
        }

        public static int GetNbOccurrenceOfWord(this IEnumerable<string> self, string word)
        {
            var result = FindLinesOfWord(self, word);
            return result.Length;
        }

        public static int[] FindLinesOfWord(this IEnumerable<string> self, string word) 
        { 
            var output = new List<int>();
            int idLine = 0;
            foreach(var line in self)
            {
                var result = FindWordInLine(word, line);

                foreach (var index in result)
                {
                    output.Add(idLine);
                }

                idLine++;
            }

            return output.ToArray();
        }

        public static int[] FindWordInLine(string word, string line)
        {
            var output = new List<int>();
            int i = 0;
            while (true)
            {
                var index = line.IndexOf(word, i);
                if (-1 == index)
                {
                    break;
                }

                // vérifier que le caractère d'avant et d'après n'est pas une lettre
                if ((index == 0 || false == char.IsLetter(line[index - 1]))
                    && (index + word.Length == line.Length || false == char.IsLetter(line[index + word.Length]))
                    )
                {
                    output.Add(index);
                }

                i = index + word.Length;
            }

            return output.ToArray();
        }
    }
}
