using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Chant
    {
        public readonly string[] _lignes;

        public int NbPages
        { 
            get
            {
                if (_lignes.Length % NbLignesParPage == 0)
                {
                    return _lignes.Length / NbLignesParPage;
                }

                return _lignes.Length / NbLignesParPage + 1;
            }
        }

        public string[] GetLinesOfPage(int page)
        {
            var output = new List<string>();

            int idFirstLine = NbLignesParPage *(page - 1);
            for (int i = 0; i < NbLignesParPage; i++)
            {
                int idLine = idFirstLine + i;
                if (idLine > _lignes.Length - 1)
                {
                    break;
                }

                output.Add(_lignes[idLine]);
            }

            return output.ToArray();
        }

        public Chant(string[] lignes)
        {
            _lignes = lignes ?? throw new ArgumentNullException(nameof(lignes));
        }

        public const int NbLignesParPage = 50;
    }
}
