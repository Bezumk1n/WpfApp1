using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace WpfApp1
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private int _score;
        private int _highScore;
        private List<List<Cell>> _arena;
        private List<Cell> _arena2 = new List<Cell>();
        private Game _game;
        private bool _gameRunning;
        private bool _gameOver;
        private ICommand _moveCommand;
        private ICommand _startCommand;

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
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        public int HighScore
        {
            get => _highScore;
            set
            {
                _highScore = value;
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
        public List<List<Cell>> Arena
        {
            get => _arena
                ;
            set
            {
                _arena = value;
                OnPropertyChanged();
            }
        }
        public List<Cell> Arena2
        {
            get => _arena2
                ;
            set
            {
                _arena2 = value;
                OnPropertyChanged();
            }
        }

        public bool GameRunning
        {
            get => _gameRunning;
            set
            {
                _gameRunning = value;
                OnPropertyChanged();
            }
        }

        public bool GameOver
        {
            get => _gameOver;
            set
            {
                _gameOver = value;
                OnPropertyChanged();
            }
        }

        public ICommand NewGameCommand { get; private set; } 
        public ICommand ClickOnHeaderCommand { get; private set; } 
        public ICommand SelectAllCommand { get; private set; } 
        public ICommand StartCommand => _startCommand ??= new RelayCommand(parameter =>
        {
            if (!GameRunning)
            {
                if (GameOver)
                    NewGame();
                else
                {
                    GameRunning = true;
                    _game.Start();
                }
            }
            else
            {
                GameRunning = false;
                _game.Stop();
            }
        });

        public ICommand MoveCommand => _moveCommand ??= new RelayCommand(parameter =>
        {
            if (GameRunning && Enum.TryParse(parameter.ToString(), out Direction direction))
            {
                _game.Direction = direction;
            }
        });

        public void EndGame()
        {
            GameRunning = false;
            GameOver = true;
            if (HighScore < Score)
                HighScore = Score;
        }

        private void NewGame()
        {
            if (GameRunning)
                _game.Stop();
            GameOver = false;
            Score = 0;
            _game = new Game(this, Rows, Columns);
            Arena = _game.Arena;
            Arena2 = _game.Arena2;

            SetColumnsHeaders();
            SetRowsHeaders();
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
            NewGameCommand = new RelayCommand(a => NewGame());
            ClickOnHeaderCommand = new RelayCommand(a => ClickOnHeader(a));
            SelectAllCommand = new RelayCommand(a => SelectAll());
        }

        private void SelectAll()
        {
            if (Arena2.All(q => q.IsSelected))
                Arena2.Select(q => q.IsSelected = false).ToList();
            else
                Arena2.Select(q => q.IsSelected = true).ToList();
        }

        private void ClickOnHeader(object a)
        {
            var type = a.GetType();

            if (type == typeof(string))
            {
                var column = int.Parse(a.ToString());
                Arena2.Where(q=>q.Column == column).Select(q => q.IsSelected = true).ToList();
            }
            else
            { 
                var row = ((char)a - 65) + 1;
                Arena2.Where(q => q.Row == row).Select(q => q.IsSelected = true).ToList();
            }
        }
    }  
}
