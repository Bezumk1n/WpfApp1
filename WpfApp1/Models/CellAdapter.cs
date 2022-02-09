using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    public class CellAdapter : BaseCell
    {
        public object CellContent { get; set; }
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

        public CellAdapter CreateCell(int index, int row, int column, object context)
        {
            Index = index;
            Row = row;
            Column = column;
            CellContent = context;

            return this;
        }
    }
}
