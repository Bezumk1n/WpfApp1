using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private int _Columns = 12;
        public int Columns
        {
            get => _Columns;
            set
            {
                if (value != null)
                {
                    _Columns = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _Rows = 8;
        public int Rows
        {
            get => _Rows;
            set
            {
                if (value != null)
                {
                    _Rows = value;
                    OnPropertyChanged();
                }
            }
        }
       
        private List<Cell> _reactionBlock = new List<Cell>();
        public List<Cell> ReactionBlock
        {
            get => _reactionBlock;
            set
            {
                _reactionBlock = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand NewGameCommand { get; private set; } 

        private void CreateReactionBlock()
        {
            var list = new List<Cell>();
            var index = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    list.Add(new Cell() { Index = index++, Row = i + 1, Column = j + 1 });
            }
            ReactionBlock = list;
        }

        public MainViewModel()
        {
            CreateReactionBlock();

            NewGameCommand = new RelayCommand(a => CreateReactionBlock());
        }

        private void ClickOnHeader(object a)
        {
            var type = a.GetType();

            if (type == typeof(string))
            {
                var column = int.Parse(a.ToString());
                ReactionBlock.Where(q=>q.Column == column).Select(q => q.IsSelected = true).ToList();
            }
            else
            { 
                var row = ((char)a - 65) + 1;
                ReactionBlock.Where(q => q.Row == row).Select(q => q.IsSelected = true).ToList();
            }
        }
    }  
}
