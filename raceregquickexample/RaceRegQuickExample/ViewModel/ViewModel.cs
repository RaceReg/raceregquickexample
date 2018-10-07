using RaceRegQuickExample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RaceRegQuickExample.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        //Race currentRace;
        private Race currentRace;
        public Race CurrentRace
        {
            get
            {
                return currentRace;
            }
            set
            {
                currentRace = value;
                NotifyPropertyChanged(nameof(CurrentRace));
            }
        }

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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
