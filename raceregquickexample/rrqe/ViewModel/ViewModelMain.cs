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

        private RelayCommand addTime;


        public ViewModelMain()
        {
            RaceRecords = new ObservableCollection<RaceRecord>
            {
                new RaceRecord{FirstName="Jackson", LastName="Porter", Age=21, Gender=Gender.Male},
                new RaceRecord{FirstName="Alex", LastName="Thayn", Age=24, Gender=Gender.Male},
                new RaceRecord{FirstName="Leedan", LastName="Johnson", Age=23, Gender=Gender.Male},
            };

            void AddRacer(object parameter)
            {
                if(parameter == null)
                {
                    return;
                }
                RaceRecords.Add(new RaceRecord {FirstName = parameter.ToString(), LastName = parameter.ToString(),  Age = Int32.Parse(parameter.ToString()), Gender = parameter.ToString() })
            }
        }
    }
}
