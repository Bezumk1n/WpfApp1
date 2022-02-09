using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfApp1.Models;

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
                _Columns = value;
                OnPropertyChanged();
            }
        }

        private int _Rows = 8;
        public int Rows
        {
            get => _Rows;
            set
            {
                _Rows = value;
                OnPropertyChanged();
            }
        }
       
        private List<CellAdapter> _reactionBlockItems = new List<CellAdapter>();
        public List<CellAdapter> ReactionBlockItems
        {
            get => _reactionBlockItems;
            set
            {
                _reactionBlockItems = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand NewReactionBlockCommand { get; private set; }

        public MainViewModel()
        {
            CreateReactionBlock();

            NewReactionBlockCommand = new RelayCommand(a => CreateReactionBlock());
        }

        private void CreateReactionBlock()
        {
            var list = new List<ReactionBlockCell>();
            var index = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    list.Add(new ReactionBlockCell().CreateCell(index: index++, row: i + 1, column: j + 1)) ;
            }

            var nlist = new List<CellAdapter>();
            var idx = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var item = new CellAdapter();
                    item.Create(idx, i+1,j+1, list[idx]);
                    idx++;
                    nlist.Add(item);
                }
            }
            ReactionBlockItems = nlist;
        }

    }  
}
