using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Katan.Models
{
    public class Register
    {
        #region Fields
        private int _rank;
        private string _name;
        private List<int> _arr;
        #endregion

        #region Properties

        public int Rank
        {
            get => _rank;

            set
            {
                _rank = value;
                OnPropertyChanged("Rank");
            }
        }
        public string Name
        {
            get => _name;

            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public List<int> Arr
        {
            get => _arr;

            set
            {
                _arr = value;
                OnPropertyChanged("Arr");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
