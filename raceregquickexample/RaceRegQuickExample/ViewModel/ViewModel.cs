using RaceRegQuickExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceRegQuickExample.ViewModel
{
    class ViewModel
    {
        Race currentRace;

        public ViewModel()
        {
            currentRace = new Race();
            currentRace.RaceTitle = "TestRace";
            currentRace.StartDate_Time = DateTime.Today;
            currentRace.RaceDescription = "This is crazy.";

            Racer tempRacer = new Racer();
            tempRacer.FirstName = "Alex";
            tempRacer.LastName = "Thayn";
            tempRacer.Gender = "Male";
            tempRacer.Age = 25;

            currentRace.racers.Add(tempRacer);
        }
        
    }
}
