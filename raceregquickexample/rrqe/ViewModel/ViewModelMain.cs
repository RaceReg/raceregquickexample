using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rrqe.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        public ObservableCollection<RaceRecord> RaceRecords { get; set; }

        object _SelectedRecord;
        public object SelectedRecord
        {
            get
            {
                return _SelectedRecord;
            }
            set
            {
                if(_SelectedRecord != value)
                {
                    _SelectedRecord = value;
                    RaisePropertyChanged("SelectedRecord");
                }
            }
        }

        string _TextProperty1;
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if(_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                    RaisePropertyChanged("TextProperty1");
                }
            }
        }

        private RelayCommand AddRacerCommand {get; set;}


        public ViewModelMain()
        {
            RaceRecords = new ObservableCollection<RaceRecord>
            {
                new RaceRecord{FirstName="Jackson", LastName="Porter", Age=21, Gender="Male"},
                new RaceRecord{FirstName="Alex", LastName="Thayn", Age=24, Gender="Male"},
                new RaceRecord{FirstName="Leedan", LastName="Johnson", Age=23, Gender="Male"},
            };
            TextProperty1 = "Type Your New Racer Here";

            AddRacerCommand = new RelayCommand(AddRacer);

            void AddRacer(object parameter)
            {
                if(parameter == null)
                {
                    return;
                }
                RaceRecords.Add(new RaceRecord
                {
                    FirstName = parameter.ToString(),
                    LastName = parameter.ToString(),
                    Age = Int32.Parse(parameter.ToString()),
                    Gender = parameter.ToString()
                });
            }
        }
    }
}
