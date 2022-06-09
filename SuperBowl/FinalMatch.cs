using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SuperBowl
{
    class FinalMatch
    {
        public RomaiSorszam Ssz { get; set; }
        public string Date { get; set; }
        public string WinnerGroup { get; set; }
        public string Result { get; set; }
        public string LooserGroup { get; set; }
        public string Location { get; set; }
        public string CityState { get; set; }
        public int WatcherCount { get; set; }

        // BAD PERFORMANCE
        private int[] ResultParts => Result.Split("-").Select(int.Parse).ToArray();
        public int Points1 => ResultParts[0];
        public int Points2 => ResultParts[1];

        public int PointDifference
        {
            get
            {
                return Math.Max(Points1, Points2) - Math.Min(Points1, Points2);
            }
        }

        public FinalMatch(string row)
        {
            string[] data = row.Split(';');
            Ssz = new RomaiSorszam(data[0]);
            Date = data[1];
            WinnerGroup = data[2];
            Result = data[3];
            LooserGroup = data[4];
            Location = data[5];
            CityState = data[6];
            WatcherCount = int.Parse(data[7]);
        }

    }
}
