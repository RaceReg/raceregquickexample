using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RaceRegQuickExample.Model
{
    public class Racer : IDataErrorInfo, INotifyPropertyChanged
    {
        public Dictionary<string, string> errors = new Dictionary<string, string>();

        public string Error => throw new NotImplementedException();
        public string this[string columnName] => errors.ContainsKey(columnName) ? errors[columnName] : null;


        private string _FirstName;
        private string _LastName;
        private int _Age;

        private void ValidateFirstName()
        {
            if (FirstName == null || FirstName.Any(Char.IsWhiteSpace))
            {
                errors[nameof(FirstName)] = "First name must contain no spaces, and cannot be empty.";
            }
            else
            {
                errors[nameof(FirstName)] = null;
            }

            OnPropertyChanged(nameof(FirstName));
        }

        private void ValidateLastName()
        {
            if (LastName == null || LastName.Any(Char.IsWhiteSpace))
            {
                errors[nameof(LastName)] = "Last name must contain no spaces, and cannot be empty.";
            }
            else
            {
                errors[nameof(LastName)] = null;
            }

            OnPropertyChanged(nameof(LastName));

        }

        private void ValidateAge()
        {
            if (Age < 1 || Age > 150)
            {
                errors[nameof(Age)] = "Age must be between 1 and 150.";
            }
            else
            {
                errors[nameof(Age)] = null;
            }

            OnPropertyChanged(nameof(Age));

        }

        public String FirstName {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                OnPropertyChanged(nameof(FirstName));
                ValidateFirstName();
            }
        }
        public String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                OnPropertyChanged(nameof(LastName));
                ValidateLastName();
            }
        }
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
                OnPropertyChanged(nameof(Age));
                ValidateAge();
            }
        }
        public String Gender { get; set; }
        public DateTime FinishTime { get; set; }

        public string GetToString()
        {
            return FirstName + ";" + LastName + ";" + Age + ";" + Gender + ";" + FinishTime.ToShortDateString();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
