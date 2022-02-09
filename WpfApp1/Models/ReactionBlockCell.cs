using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfApp1.Models
{
    public class ReactionBlockCell : BaseCell
    {
        public int Index { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Position { get; set; }

        public ReactionBlockCell CreateCell(int index, int row, int column)
        {
            Index = index;
            Row = row;
            Column = column;
            Position = $"{row}, {column}";

            return this;
        }
    }
}
