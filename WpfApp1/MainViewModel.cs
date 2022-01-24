using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainViewModel : NotifyPropertyChanged
    {

        private List<Cell> _reactionBlock = new List<Cell>();

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
       
        private IEnumerable<char> _RowsHeaders;
        public IEnumerable<char> RowsHeaders
        {
            get => _RowsHeaders;
            set
            {
                _RowsHeaders = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<string> _ColumnsHeaders;
        public IEnumerable<string> ColumnsHeaders
        {
            get => _ColumnsHeaders;
            set
            {
                _ColumnsHeaders = value;
                OnPropertyChanged();
            }
        }
      
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
        public ICommand ClickOnHeaderCommand { get; private set; } 
        public ICommand SelectAllCommand { get; private set; } 
       

        private void NewReactionBlock()
        {
            CreateReactionBlock();
            SetColumnsHeaders();
            SetRowsHeaders();
        }

        private void CreateReactionBlock()
        {
            var rb = new List<Cell>();
            var index = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    rb.Add(new Cell() { Index = index++, Row = i + 1, Column = j + 1 });
            }
            ReactionBlock = rb;
        }

        private void SetColumnsHeaders()
        {
            var columnsHeaders = new List<string>();
            for (int i = 1; i <= Columns; i++)
                columnsHeaders.Add(i.ToString("00"));
            ColumnsHeaders = columnsHeaders.ToArray();
        }

        private void SetRowsHeaders()
        {
            var rowsHeaders = "";
            for (int i = 0; i < Rows; i++)
            {
                var c = (char)(65 + i);
                rowsHeaders += c;
            }
            RowsHeaders = rowsHeaders;
        }

        public MainViewModel()
        {
            NewReactionBlock();

            NewGameCommand = new RelayCommand(a => NewReactionBlock());
            ClickOnHeaderCommand = new RelayCommand(a => ClickOnHeader(a));
            SelectAllCommand = new RelayCommand(a => SelectAll());
        }

        private void SelectAll()
        {
            if (ReactionBlock.All(q => q.IsSelected))
                ReactionBlock.Select(q => q.IsSelected = false).ToList();
            else
                ReactionBlock.Select(q => q.IsSelected = true).ToList();
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
