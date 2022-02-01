using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    public class BaseCell : NotifyPropertyChanged
    {
        public int Index { get; set; }
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
    }
}
