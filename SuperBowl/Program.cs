using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SuperBowl
{
    class Program
    {

        private const string FilePath = "SuperBowl.txt";
        private const string OutputFilePath = "SuperBowlNew.txt";

        static void Main(string[] args)
        {
            List<FinalMatch> elements = File.ReadLines(FilePath)
                .Skip(1)
                .Select(it => new FinalMatch(it))
                .ToList();

            PrintTask(4, $"Döntők száma: {elements.Count}");

            double averagePointDifference = 
                Math.Round(elements.Select(it => it.PointDifference).Average(), 1);

            PrintTask(5, $"Átlagos pontkülönbség: {averagePointDifference}");

            FinalMatch mostWatched = elements.Aggregate((o1, o2) => o1.WatcherCount > o2.WatcherCount ? o1 : o2);
            string toPrint = string.Join(
                "\n\t",
                "Legmagasabb nézőszám a döntők során: ",
                $"Sorszám (dátum): {mostWatched.Ssz.ArabSsz} ({mostWatched.Date})",
                $"Győztes csapat: {mostWatched.WinnerGroup}, szerzett pontok: {mostWatched.Points1}",
                $"Vesztes csapat: {mostWatched.LooserGroup}, szerzett pontok: {mostWatched.Points2}",
                $"Helyszín: {mostWatched.Location}",
                $"Város, állam: {mostWatched.CityState}",
                $"Nézőszám: {mostWatched.WatcherCount}"
            ) ;

            PrintTask(6, toPrint);

            using (StreamWriter sw = new StreamWriter(OutputFilePath))
            {
                sw.WriteLine("Ssz;Dátum;Győztes;Eredmény;Vesztes;Nézőszám");
                foreach(var finalMatch in elements)
                {
                    int winnerGroupCount = elements.Count(it => new string[] { it.WinnerGroup, it.LooserGroup }.Contains(finalMatch.WinnerGroup));
                    int looserGroupCount = elements.Count(it => new string[] { it.WinnerGroup, it.LooserGroup  }.Contains(finalMatch.LooserGroup));
                    sw.WriteLine(
                        $"{finalMatch.Ssz.ArabSsz};" +
                        $"{finalMatch.Date};" +
                        $"{finalMatch.WinnerGroup} ({winnerGroupCount});" +
                        $"{finalMatch.Result};" +
                        $"{finalMatch.LooserGroup} ({looserGroupCount});" +
                        $"{finalMatch.WatcherCount}"
                    );
                }
            }


            Console.ReadKey();
        }

        private static void PrintTask(int n, string message)
        {
            Console.WriteLine($"{n}. Feladat: {message}");
        }
    }
}
