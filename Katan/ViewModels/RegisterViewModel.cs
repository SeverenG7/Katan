using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Katan.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private Models.Register _register;
        public Models.Register SpecialRegister
        {
            get => _register;

            set
            {
                _register = value;
                OnPropertyChanged("SpecialRegister");
            }

        }

        private string _example;

        public string Example
        {
            get => _example ??
               "Example Here";
            set
            {
                _example = value;
                OnPropertyChanged("Example");
            }
        }


        public RegisterViewModel()
        {
            SpecialRegister = new Models.Register() { Rank = 5, Name = "L1", Arr = new List<int>() {1,0,1 } };
        }
    }
}
