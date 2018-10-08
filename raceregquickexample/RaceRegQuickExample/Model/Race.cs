using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceRegQuickExample.Model
{
    public class Race
    {
        public String RaceTitle { get; set; }
        public DateTime StartDate_Time { get; set; }
        public String RaceDescription { get; set; }
        public ObservableCollection<Racer> racers { get; set; }

        public Race()
        {
            racers = new ObservableCollection<Racer>();
        }

        public string GetToString()
        {
            string raceData = RaceTitle + ";" + StartDate_Time.ToShortDateString() + ";" +
                RaceDescription + ";" + "\n";
            for (int i = 0; i < racers.Count; i++)
            {
                raceData += racers.ElementAt(i).GetToString() + "\n";
            }
            return raceData;
        }
    }
}
