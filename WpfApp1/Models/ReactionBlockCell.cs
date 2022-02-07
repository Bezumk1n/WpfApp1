using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfApp1.Models
{
    public class ReactionBlockCell : BaseCell
    {
        public object CellContext { get; set; }
        public int Index { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Position { get; set; }


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

        public ReactionBlockCell CreateCell(int index, int row, int column, object context)
        {
            Index = index;
            Row = row;
            Column = column;
            Position = $"{row}, {column}";
            CellContext = context;

            return this;
        }
    }
}
