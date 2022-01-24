
using System;

namespace WpfApp1
{
    public class Cell : NotifyPropertyChanged
    {
        public int Index { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
        public string Position => GetPosition();

        private string GetPosition()
        {
            return $"{Row}, {Column}";
        }
    }
}
