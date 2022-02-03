﻿
using System;

namespace WpfApp1.Models
{
    public class Cell : NotifyPropertyChanged
    {
        public int Index { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Position { get; set; }
        public string Biomaterial { get; set; }

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

        public Cell()
        {
            
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
