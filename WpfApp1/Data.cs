
using System;

namespace WpfApp1
{
    public class Cell : NotifyPropertyChanged
    {
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
        public string Position => GetPosition();

        private string GetPosition()
        {
            return $"{Row}, {Column}";
        }

        private CellState _state;

        public CellState State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }
    }

    public enum CellState
    {
        Empty,
        Snake,
        Food
    }

    public enum Direction
    {
        Right,
        Down,
        Left,
        Up
    }

    public struct Coords
    {
        public int X { get; }
        public int Y { get; }

        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
