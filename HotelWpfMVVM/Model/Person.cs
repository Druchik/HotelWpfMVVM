﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HotelWpfMVVM.Model
{
    public class Person : INotifyPropertyChanged
    {
        private int _personId;
        private string _firstName;
        private string _lastName;
        private DateTime? _birthdate;

        public int PersonId
        {
            get => _personId;
            set
            {
                if (value == _personId) return;
                _personId = value;
                //OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == _firstName) return;
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public DateTime? Birthdate
        {
            get => _birthdate;
            set
            {
                if (value.Equals(_birthdate)) return;
                _birthdate = value;
                OnPropertyChanged("Birthdate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
