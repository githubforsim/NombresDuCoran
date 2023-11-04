using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Série
    {
        public Série(List<int> list)
        {
            _nombres = list.ToArray();
        }
        public Série(string listAsString)
        {
            var numbersAsString = listAsString.Split(';');
            var list = new List<int>();
            for (int i = 0; i < numbersAsString.Length; i++)
            {
                var numberAsString = numbersAsString[i].Trim();
                list.Add(int.Parse(numberAsString));
            }

            _nombres = list.ToArray();
        }

        public Série()
        {
        }

        public int[] _nombres = new int[31];

        public override string ToString()
        {
            var output = _nombres[0].ToString();
            for (int i = 1; i < _nombres.Length; i++)
            {
                output += " ; " + _nombres[i].ToString();
            }

            return output;
        }

        public bool Test()
        {
            for (int i = 0; i < _nombres.Length; i++)
            {
                if (_nombres[i] < 13)
                {
                    return false;
                }
                if (_nombres[i] > 77)
                {
                    return false;
                }
            }

            for (int i = 0; i < _nombres.Length - 1; i++)
            {
                if (_nombres[i] >= _nombres[i + 1])
                {
                    return false;
                }
                if (_nombres[i] >= _nombres[i + 1])
                {
                    return false;
                }
                if (_nombres[i + 1] < _nombres[i] + 2)
                {
                    return false;
                }
                if (_nombres[i + 1] > _nombres[i] + 3)
                {
                    return false;
                }
            }

            return true;
        }

        public BigInteger SommeALaPuissance(int puissance = 1)
        {
            BigInteger output = 0;
            for (int i = 0; i < _nombres.Length; i++)
            {
                BigInteger avecLaPuissance = _nombres[i];
                for (int j = 1; j < puissance; j++)
                {
                    avecLaPuissance *= _nombres[i];
                }

                output += avecLaPuissance;
            }

            return output;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Série> series = CreateSeries();
            TestSeriesCritèresCoran(series);

            AffichageDeSériesAvecFiltre(series);

            int id = 33897;
            var serie = series[id];
            //for(int p = 1; p < 60; p++)
            //{
            //    var res = serie.SommeALaPuissance(p);
            //    Debug.WriteLine("p = " + p + " : " + res);
            //    Console.WriteLine("p = " + p + " : " + res);
            //}

            //var randomer = new Random();
            //var nbEssais = 10000;
            //for (int j = 1; j < nbEssais; j++)
            //{
            //    int id = randomer.Next(0, series.Count);
            //    var serie = series[id];
            //    var serie_tmp = new List<int>();

            //    if (IsSerieFonctionneJusquaLaPuissance(4, serie))
            //    {
            //        series.Add(serie);
            //        Debug.WriteLine("La série fonctionne : " + serie.ToString());
            //        Console.WriteLine("La série fonctionne : " + serie.ToString());
            //    }
            //}

            //7 puissances jusqu'à 10 : new Série("63 ; 60 ; 58 ; 66 ; 56 ; 69 ; 21 ; 14 ; 20 ; 27 ; 55 ; 59 ; 18 ; 29 ; 15 ; 16 ; 57 ; 36 ; 64 ; 75 ; 61 ; 34 ; 49 ; 73 ; 42 ; 71 ; 72 ; 50 ; 30 ; 46 ; 47"),

            //var series = new List<Série>()
            //{
            //    new Série("63 ; 60 ; 58 ; 66 ; 56 ; 69 ; 21 ; 14 ; 20 ; 27 ; 55 ; 59 ; 18 ; 29 ; 15 ; 16 ; 57 ; 36 ; 64 ; 75 ; 61 ; 34 ; 49 ; 73 ; 42 ; 71 ; 72 ; 50 ; 30 ; 46 ; 47"),
            //    new Série("80 ; 18 ; 42 ; 94 ; 41 ; 75 ; 88 ; 15 ; 68 ; 62 ; 74 ; 63 ; 32 ; 40 ; 51 ; 100 ; 54 ; 87 ; 13 ; 31 ; 65 ; 98 ; 67 ; 36 ; 25 ; 72 ; 52 ; 29 ; 55 ; 45 ; 69"),
            //    new Série("99 ; 50 ; 41 ; 25 ; 40 ; 62 ; 37 ; 23 ; 91 ; 84 ; 60 ; 98 ; 20 ; 22 ; 79 ; 67 ; 73 ; 13 ; 81 ; 15 ; 77 ; 26 ; 70 ; 18 ; 31 ; 33 ; 97 ; 58 ; 66 ; 92 ; 51"),
            //    new Série("77 ; 88 ; 36 ; 94 ; 53 ; 98 ; 33 ; 37 ; 17 ; 99 ; 63 ; 86 ; 61 ; 69 ; 52 ; 46 ; 84 ; 15 ; 74 ; 41 ; 21 ; 42 ; 92 ; 64 ; 49 ; 56 ; 93 ; 68 ; 32 ; 20 ; 51"),
            //    new Série("90 ; 60 ; 95 ; 16 ; 98 ; 93 ; 36 ; 25 ; 92 ; 84 ; 38 ; 47 ; 73 ; 42 ; 88 ; 48 ; 61 ; 13 ; 29 ; 33 ; 83 ; 26 ; 37 ; 41 ; 100 ; 66 ; 94 ; 40 ; 96 ; 18 ; 15"),
            //    new Série("40 ; 31 ; 44 ; 46 ; 79 ; 26 ; 15 ; 37 ; 91 ; 72 ; 20 ; 51 ; 65 ; 97 ; 96 ; 29 ; 23 ; 19 ; 66 ; 99 ; 67 ; 62 ; 68 ; 48 ; 59 ; 98 ; 93 ; 22 ; 32 ; 49 ; 25"),
            //    new Série("74 ; 19 ; 36 ; 88 ; 41 ; 100 ; 91 ; 48 ; 47 ; 82 ; 34 ; 40 ; 71 ; 93 ; 59 ; 86 ; 69 ; 80 ; 94 ; 70 ; 16 ; 18 ; 54 ; 83 ; 27 ; 39 ; 30 ; 92 ; 28 ; 46 ; 76"),
            //    new Série("25 ; 93 ; 42 ; 88 ; 63 ; 35 ; 29 ; 26 ; 40 ; 100 ; 77 ; 34 ; 18 ; 50 ; 67 ; 79 ; 31 ; 81 ; 45 ; 27 ; 17 ; 82 ; 56 ; 19 ; 52 ; 85 ; 66 ; 92 ; 44 ; 49 ; 87"),
            //    new Série("55 ; 98 ; 23 ; 85 ; 18 ; 97 ; 84 ; 73 ; 59 ; 71 ; 80 ; 76 ; 81 ; 72 ; 38 ; 93 ; 15 ; 40 ; 47 ; 91 ; 48 ; 26 ; 89 ; 92 ; 14 ; 60 ; 63 ; 70 ; 24 ; 90 ; 79")
            //};
            //CalculDuNombreDePuissancesDonnantUnNombrePremier(series);

            //IdentificationDeSériesAléatoires();

            //AffichageDeSériesAvecFiltre(series);

            //CalculsAvecLaSérieDuCoran(series);

            //CalculEffectifsDeSériesAvecFiltre(series);

            //CalculDuNombreDePuissancesDonnantUnNombrePremier(series, 10);

            Console.WriteLine("Calcul terminé");
            Console.ReadKey();
        }

        private static void IdentificationDeSériesAléatoires()
        {
            var randomer = new Random();
            var nbEssais = 10000;
            var series = new List<Série>();
            for (int j = 1; j < nbEssais; j++)
            {
                var serie_tmp = new List<int>();
                while (serie_tmp.Count < 31)
                {
                    int entier = randomer.Next(13, 78);
                    //int entier = randomer.Next(7, 72);
                    if (serie_tmp.Contains(entier))
                    {
                        continue;
                    }
                    serie_tmp.Add(entier);
                }

                var serie = new Série(serie_tmp);

                if (IsSerieFonctionneJusquaLaPuissance(4, serie))
                {
                    series.Add(serie);
                    Debug.WriteLine("La série fonctionne : " + serie.ToString());
                    Console.WriteLine("La série fonctionne : " + serie.ToString());
                }
            }
            CalculDuNombreDePuissancesDonnantUnNombrePremier(series, 10);
            Debug.WriteLine("Nb de tirs effectués : " + nbEssais);
            Console.WriteLine("Nb de tirs effectués : " + nbEssais);
        }

        private static void TestSeriesCritèresCoran(List<Série> series)
        {
            foreach (var serie in series)
            {
                if (false == serie.Test())
                {
                    throw new Exception();
                }
            }
        }

        private static void AffichageDeSériesAvecFiltre(List<Série> series)
        {
            for (int i = 0; i < series.Count; i++)
            {
                var serie = series[i];

                if (IsPremier(serie.SommeALaPuissance(1), out BigInteger diviseur)
                    && IsPremier(serie.SommeALaPuissance(2), out diviseur)
                    && IsPremier(serie.SommeALaPuissance(3), out diviseur)
                    && IsPremier(serie.SommeALaPuissance(4), out diviseur)
                    && IsPremier(serie.SommeALaPuissance(5), out diviseur)
                    && IsPremier(serie.SommeALaPuissance(6), out diviseur)
                    && IsPremier(serie.SommeALaPuissance(7), out diviseur)
                    && IsPremier(serie.SommeALaPuissance(8), out diviseur)
                    )
                {
                    Debug.WriteLine("La série n°" + i + " fonctionne : " + serie.ToString());
                    Console.WriteLine("La série n°" + i + " fonctionne : " + serie.ToString());
                }
            }
        }

        private static void CalculsAvecLaSérieDuCoran(List<Série> series)
        {
            {
                var serieCoran = series[10276];
                for (int p = 1; p <= 10; p++)
                {
                    BigInteger nombre = serieCoran.SommeALaPuissance(p);
                    Debug.WriteLine("Nombre pour la puissance " + p + " est de " + nombre);
                    Console.WriteLine("Nombre pour la puissance " + p + " est de " + nombre);
                }
            }
            {
                var serieCoran = series[10276];
                for (int p = 1; p <= 9; p++)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    sw.Start();
                    BigInteger nombre = serieCoran.SommeALaPuissance(p);
                    IsPremierThéorique(nombre, out BigInteger diviseur);
                    sw.Stop();
                    Debug.WriteLine("Durée d'exécution à la puissance " + p + " est de " + sw.ElapsedMilliseconds + " ms pour le nombre " + nombre);
                    Console.WriteLine("Durée d'exécution à la puissance " + p + " est de " + sw.ElapsedMilliseconds + " ms pour le nombre " + nombre);
                }
            }
        }

        private static void CalculEffectifsDeSériesAvecFiltre(List<Série> series)
        {
            var effectif = 0;
            for (int i = 0; i < series.Count; i++)
            {
                var serie = series[i];

                if (IsPremier(serie.SommeALaPuissance(1), out BigInteger diviseur)
                    && IsPremier(serie.SommeALaPuissance(2), out diviseur)
                    && IsPremier(serie.SommeALaPuissance(3), out diviseur)
                    && false == IsPremier(serie.SommeALaPuissance(4), out diviseur)
                    && false == IsPremier(serie.SommeALaPuissance(5), out diviseur)
                    && false == IsPremier(serie.SommeALaPuissance(6), out diviseur)
                    && false == IsPremier(serie.SommeALaPuissance(7), out diviseur)
                    && IsPremier(serie.SommeALaPuissance(8), out diviseur)
                    //&& IsPremier(serie.Somme(5), out diviseur)
                    //&& IsPremier(serie.Somme(6), out diviseur)
                    )
                {
                    Debug.WriteLine("La série n°" + i + " fonctionne : " + serie.ToString());
                    Console.WriteLine("La série n°" + i + " fonctionne : " + serie.ToString());
                    effectif++;
                }
            }
            Debug.WriteLine("Effectif total = " + effectif);
            Console.WriteLine("Effectif total = " + effectif);
        }

        private static void CalculDuNombreDePuissancesDonnantUnNombrePremier(List<Série> series, int Pmax = 9)
        {
            var idSeries = GetSeriesQuiFonctionnentJusquaPuissance(3, series);
            foreach (var id in idSeries)
            {
                var serie = series[id];
                var puissances = "1, 2, 3";
                int nbOk = 3;
                for (int p = 4; p <= Pmax; p++)
                {
                    if (TestPuissance(serie, p, out BigInteger diviseur))
                    {
                        nbOk++;
                        puissances += ", " + p;
                    }
                }

                //if (nbOk < 6)
                //{
                //    continue;
                //}

                Debug.WriteLine("La série n°" + id + " fonctionne pour " + nbOk + " puissances jusqu'à " + Pmax + " : " + puissances);
                Console.WriteLine("La série n°" + id + " fonctionne pour " + nbOk + " puissances jusqu'à " + Pmax + " : " + puissances);
                Debug.WriteLine("La série n°" + id + " fonctionne : " + serie.ToString());
                Console.WriteLine("La série n°" + id + " fonctionne : " + serie.ToString());
            }
        }

        private static int[] GetSeriesQuiFonctionnentJusquaPuissance(int p, List<Série> series)
        {
            var output = new List<int>();

            for (int i = 0; i < series.Count; i++)
            {
                var serie = series[i];
                bool result = IsSerieFonctionneJusquaLaPuissance(p, serie);

                if (result)
                {
                    output.Add(i);
                }
            }

            return output.ToArray();
        }

        private static bool IsSerieFonctionneJusquaLaPuissance(int p, Série serie)
        {
            var result = true;
            for (int j = 1; j <= p; j++)
            {
                if (false == IsPremier(serie.SommeALaPuissance(j), out BigInteger diviseur))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private static bool TestPuissance(Série serie, int puissance, out BigInteger diviseur)
        {
            return IsPremier(serie.SommeALaPuissance(puissance), out diviseur);
        }

        private static List<Série> CreateSeries()
        {
            var série1 = new List<Série>();
            for (int n0 = 13; n0 <= 17; n0++)
            {
                var newSérie = new Série();
                newSérie._nombres[0] = n0;
                for (int i = 1; i < 31; i++)
                {
                    newSérie._nombres[i] = newSérie._nombres[i - 1] + 2;
                }

                série1.Add(newSérie);
            }

            var série2 = new List<Série>();
            for (int n0 = 13; n0 <= 16; n0++)
            {
                for (int j = 1; j < 31; j++)
                {
                    var newSérie = new Série();
                    newSérie._nombres[0] = n0;
                    for (int i = 1; i < 31; i++)
                    {
                        if (i == j)
                        {
                            newSérie._nombres[i] = newSérie._nombres[i - 1] + 3;
                        }
                        else
                        {
                            newSérie._nombres[i] = newSérie._nombres[i - 1] + 2;
                        }
                    }

                    série2.Add(newSérie);
                }

            }

            var série3 = new List<Série>();
            for (int n0 = 13; n0 <= 15; n0++)
            {
                for (int k = 1; k < 31; k++)
                {
                    for (int j = 1; j < 31; j++)
                    {
                        if (j >= k)
                        {
                            continue;
                        }

                        var newSérie = new Série();
                        newSérie._nombres[0] = n0;
                        for (int i = 1; i < 31; i++)
                        {
                            if (i == j || i == k)
                            {
                                newSérie._nombres[i] = newSérie._nombres[i - 1] + 3;
                            }
                            else
                            {
                                newSérie._nombres[i] = newSérie._nombres[i - 1] + 2;
                            }
                        }

                        série3.Add(newSérie);
                    }
                }

            }

            var série4 = new List<Série>();
            for (int n0 = 13; n0 <= 14; n0++)
            {
                for (int l = 1; l < 31; l++)
                {
                    for (int k = 1; k < 31; k++)
                    {
                        for (int j = 1; j < 31; j++)
                        {
                            if (j >= k || k >= l || j >= l)
                            {
                                continue;
                            }

                            var newSérie = new Série();
                            newSérie._nombres[0] = n0;
                            for (int i = 1; i < 31; i++)
                            {
                                if (i == j || i == k || i == l)
                                {
                                    newSérie._nombres[i] = newSérie._nombres[i - 1] + 3;
                                }
                                else
                                {
                                    newSérie._nombres[i] = newSérie._nombres[i - 1] + 2;
                                }
                            }

                            série4.Add(newSérie);
                        }
                    }
                }
            }

            var série5 = new List<Série>();
            for (int n0 = 13; n0 <= 13; n0++)
            {
                for (int m = 1; m < 31; m++)
                {
                    for (int l = 1; l < 31; l++)
                    {
                        for (int k = 1; k < 31; k++)
                        {
                            for (int j = 1; j < 31; j++)
                            {
                                if (j >= k || j >= l || j >= m
                                    || k >= l || k >= m
                                    || l >= m
                                    )
                                {
                                    continue;
                                }

                                var newSérie = new Série();
                                newSérie._nombres[0] = n0;
                                for (int i = 1; i < 31; i++)
                                {
                                    if (i == j || i == k || i == l || i == m)
                                    {
                                        newSérie._nombres[i] = newSérie._nombres[i - 1] + 3;
                                    }
                                    else
                                    {
                                        newSérie._nombres[i] = newSérie._nombres[i - 1] + 2;
                                    }
                                }

                                série5.Add(newSérie);
                            }
                        }
                    }
                }
            }

            var series = série1;
            series.AddRange(série2);
            series.AddRange(série3);
            series.AddRange(série4);
            series.AddRange(série5);
            return series;
        }

        static bool IsPremier(BigInteger n, out BigInteger diviseur)
        {
            diviseur = 0;

            if (n % 2 == 0)
            {
                diviseur = 2;
                return (n == 2);
            }
            for (BigInteger d = 3; d * d <= n; d = d + 2)
            {
                if (n % d == 0)
                {
                    diviseur = d;
                    return false;
                }
            }

            return true;
        }

        static bool IsPremierThéorique(BigInteger n, out BigInteger diviseur)
        {
            diviseur = 0;

            if (n % 2 == 0)
            {
                diviseur = 2;
                return (n == 2);
            }
            for (BigInteger d = 3; d * d <= n; d = d + 2)
            {
                if (n % d == 0)
                {
                    bool t = true;
                }
            }

            return true;
        }
    }
}
