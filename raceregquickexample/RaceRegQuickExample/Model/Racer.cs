﻿using System;
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

        private string _FirstName;
        private string _LastName;
        private int _Age;

        public Racer()
        {

        }
               
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
        }

        private void ValidateGender()
        {
            if (!Enum.IsDefined(typeof(GenderType), Gender))
            {
                errors[nameof(Gender)] = "Gender must be Male, Female or Other.";
            }
            else
            {
                errors[nameof(Gender)] = null;
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
                ValidateFirstName();
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
                ValidateLastName();
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
                ValidateAge();
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
                ValidateGender();
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
