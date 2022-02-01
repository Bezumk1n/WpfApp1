
using System;

namespace WpfApp1
{
    public class Cell : NotifyPropertyChanged
    {
        public int Index { get; }
        public int Row { get; }
        public int Column { get; }
        public string Position { get; }

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

        public Cell(int index, int row, int column)
        {
            Index = index;
            Row = row;
            Column = column;
            Position = $"{row}, {column}";
        }
    }
}
