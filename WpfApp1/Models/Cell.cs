
using System;
using WpfApp1.Enums;

namespace WpfApp1.Models
{
    public class Cell : NotifyPropertyChanged
    {
        public int Index { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Position { get; set; }
        private string _sampleName;
        public string SampleName
        {
            get => _sampleName;
            set
            {
                _sampleName = value;
                OnPropertyChanged();
            }
        }
        private Biomaterials _biomaterial;
        public Biomaterials Biomaterial
        {
            get => _biomaterial;
            set
            {
                _biomaterial = value;
                OnPropertyChanged();
            }
        }

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

        public Cell CreateCell(int index, int row, int column)
        {
            Index = index;
            Row = row;
            Column = column;
            Position = $"{row}, {column}";

            return this;
        }
    }
}
