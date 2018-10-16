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

        public enum GenderType {Male, Female, Other};
        public IEnumerable<GenderType> GenderTypes
        {
            get
            {
                return Enum.GetValues(typeof(GenderType)).Cast<GenderType>().ToList<GenderType>();
            }
        }

        private string _FirstName;
        private string _LastName;
        private int _Age;

        public Racer()
        {
            FirstName = "Jackson";
            LastName = "Porter";
            Age = 1;
            Gender = GenderType.Male;
        }

        private bool isValid;
        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }

        private void setValid()
        {
            bool fN = ValidateFirstName();
            bool lN = ValidateLastName();
            bool aG = ValidateAge();
            bool gD = ValidateGender();


            IsValid = fN && lN && aG && gD;
        }

        private bool ValidateFirstName()
        {
            if (FirstName == null || FirstName.Equals(String.Empty) || FirstName.Any(Char.IsWhiteSpace))
            {
                errors[nameof(FirstName)] = "First name must contain no spaces, and cannot be empty.";
                return false;
            }
            else
            {
                errors[nameof(FirstName)] = null;
                return true;
            }
        }

        private bool ValidateLastName()
        {
            if (LastName == null || LastName.Equals(String.Empty) || LastName.Any(Char.IsWhiteSpace))
            {
                errors[nameof(LastName)] = "Last name must contain no spaces, and cannot be empty.";
                return false;
            }
            else
            {
                errors[nameof(LastName)] = null;
                return true;
            }
        }

        private bool ValidateAge()
        {
            if (Age < 1 || Age > 150)
            {
                errors[nameof(Age)] = "Age must be between 1 and 150.";
                return false;
            }
            else
            {
                errors[nameof(Age)] = null;
                return true;
            }
        }

        private bool ValidateGender()
        {
            if (!Enum.IsDefined(typeof(GenderType), Gender))
            {
                errors[nameof(Gender)] = "Gender must be Male, Female or Other.";
                return false;
            }
            else
            {
                errors[nameof(Gender)] = null;
                return true;
            }
        }

        public String FirstName {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                //ValidateFirstName();
                setValid();
                OnPropertyChanged(nameof(FirstName));
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
                //ValidateLastName();
                setValid();
                OnPropertyChanged(nameof(LastName));
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
                //ValidateAge();
                setValid();
                OnPropertyChanged(nameof(Age));
            }
        }
        
        private GenderType gender;
        public GenderType Gender {
            get
            { 
                return gender;
            }
            set
            {
                gender = value;
                //ValidateGender();
                setValid();
                OnPropertyChanged(nameof(gender));
            }
        }
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
