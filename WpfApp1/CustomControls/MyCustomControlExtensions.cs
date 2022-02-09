﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WpfApp1.Enums;
using WpfApp1.Models;
using static WpfApp1.Helpers.EnumHelper;

namespace WpfApp1.CustomControls
{
    public partial class MyCustomControl : INotifyPropertyChanged
    {
        //Reaction plate
        #region _RowCount
        public static readonly DependencyProperty _RowCountProperty =
            DependencyProperty.Register(
                "_RowCount",
                typeof(int),
                typeof(MyCustomControl),
                new PropertyMetadata(0, new PropertyChangedCallback(On_RowCountChanged)));

        public int _RowCount
        {
            get { return (int)GetValue(_RowCountProperty); }
            set { SetValue(_RowCountProperty, value); }
        }

        private static void On_RowCountChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl UserControl1Control = d as MyCustomControl;
            UserControl1Control.On_RowCountChanged(e);
        }

        private void On_RowCountChanged(DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion
        #region _ColumnCount
        public static readonly DependencyProperty _ColumnCountProperty =
            DependencyProperty.Register(
                "_ColumnCount",
                typeof(int),
                typeof(MyCustomControl),
                new PropertyMetadata(0, new PropertyChangedCallback(On_ColumnCountChanged)));

        public int _ColumnCount
        {
            get { return (int)GetValue(_ColumnCountProperty); }
            set { SetValue(_ColumnCountProperty, value); }
        }

        private static void On_ColumnCountChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl UserControl1Control = d as MyCustomControl;
            UserControl1Control.On_ColumnCountChanged(e);
        }

        private void On_ColumnCountChanged(DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion
        #region _Items
        public static readonly DependencyProperty _ItemsProperty =
            DependencyProperty.Register(
                "_Items",
                typeof(IEnumerable<object>),
                typeof(MyCustomControl),
                new PropertyMetadata(null, new PropertyChangedCallback(On_ItemsChanged)));

        public IEnumerable<object> _Items
        {
            get { return (IEnumerable<object>)GetValue(_ItemsProperty); }
            set { SetValue(_ItemsProperty, value); }
        }
        private static void On_ItemsChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl UserControlControl = d as MyCustomControl;
            //var step = UserControlControl._ColumnCount;
            //if (step <= 0)
            //    return;
            //var items = (IEnumerable<object>)e.NewValue;
            //var count = items.Count();
            //var currentIndex = 0;
            //var list = new List<List<object>>();

            //if (UserControlControl._RowCount * UserControlControl._ColumnCount > count)
            //{
            //    throw new Exception("Reaction plate - Invalid cells count");
            //    return;
            //}
            //while (currentIndex < count)
            //{
            //    var part = items.Skip(currentIndex).Take(step).ToArray();
            //    var row = new List<object>(part);
            //    list.Add(row);
            //    currentIndex += step;
            //}
            //UserControlControl._ItemCells = list;

            UserControlControl._ItemCells = e.NewValue;

            //Headers
            if (UserControlControl._IsGenerateHeaders)
            {
                UserControlControl._ColumnsHeaders = new List<string>(
                    Enumerable.Range(1, UserControlControl._ColumnCount)
                    .Select(x => x.ToString("00")).ToList());

                UserControlControl._RowsHeaders = new List<char>(
                    Enumerable.Range(0, UserControlControl._RowCount)
                    .Select(x => Convert.ToChar(65 + x)).ToList());
            }
            else
            {
                UserControlControl._ColumnsHeaders = null;
                UserControlControl._RowsHeaders = null;
            }

            UserControlControl.On_ItemsChanged(e);
        }

        private void On_ItemsChanged(DependencyPropertyChangedEventArgs e)
        {
            
        }
        #endregion
        #region _ItemCells
        public static readonly DependencyProperty _ItemCellsProperty =
            DependencyProperty.Register(
                "_ItemCells",
                typeof(object),
                typeof(MyCustomControl),
                new PropertyMetadata(null, new PropertyChangedCallback(On_ItemCellsChanged)));

        public object _ItemCells
        {
            get { return (object)GetValue(_ItemCellsProperty); }
            private set { SetValue(_ItemCellsProperty, value); }
        }
        private static void On_ItemCellsChanged(DependencyObject d,
          DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl control = d as MyCustomControl;
            control.On_ItemCellsChanged(e);
        }
        private void On_ItemCellsChanged(DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion
        //Index
        #region _IsGenerateCellIndex
        public static readonly DependencyProperty _IsGenerateCellIndexProperty =
            DependencyProperty.Register(
                "_IsGenerateCellIndex", 
                typeof(bool), 
                typeof(MyCustomControl), 
                new PropertyMetadata(false, new PropertyChangedCallback(On_IsGenerateCellIndexChanged)));

        public bool _IsGenerateCellIndex
        {
            get { return (bool)GetValue(_IsGenerateCellIndexProperty); }
            set { SetValue(_IsGenerateCellIndexProperty, value); }
        }

        private static void On_IsGenerateCellIndexChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl UserControl1Control = d as MyCustomControl;
            UserControl1Control.On_IsGenerateCellIndexChanged(e);
        }

        private void On_IsGenerateCellIndexChanged(DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion
        //Headers
        #region _IsGenerateHeaders
        public static readonly DependencyProperty _IsGenerateHeadersProperty =
       DependencyProperty.Register("_IsGenerateHeaders", typeof(bool), typeof(MyCustomControl), new
          PropertyMetadata(false, new PropertyChangedCallback(On_IsGenerateHeadersChanged)));

        public bool _IsGenerateHeaders
        {
            get { return (bool)GetValue(_IsGenerateHeadersProperty); }
            set { SetValue(_IsGenerateHeadersProperty, value); }
        }

        private static void On_IsGenerateHeadersChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl UserControl1Control = d as MyCustomControl;
            UserControl1Control.On_IsGenerateHeadersChanged(e);
        }

        private void On_IsGenerateHeadersChanged(DependencyPropertyChangedEventArgs e)
        {
            //tbTest.Text = e.NewValue.ToString();
        }
        #endregion
        #region _ColumnsHeaders
        public static readonly DependencyProperty _ColumnsHeadersProperty =
            DependencyProperty.Register(
                "_ColumnsHeaders",
                typeof(object),
                typeof(MyCustomControl),
                new PropertyMetadata(null, new PropertyChangedCallback(On_ColumnsHeadersChanged)));

        public object _ColumnsHeaders
        {
            get { return (object)GetValue(_ColumnsHeadersProperty); }
            private set { SetValue(_ColumnsHeadersProperty, value); }
        }
        private static void On_ColumnsHeadersChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl UserControl1Control = d as MyCustomControl;
            UserControl1Control.On_ColumnsHeadersChanged(e);
        }

        private void On_ColumnsHeadersChanged(DependencyPropertyChangedEventArgs e)
        {
            
        }
        #endregion
        #region _RowsHeaders
        public static readonly DependencyProperty _RowsHeadersProperty =
            DependencyProperty.Register(
                "_RowsHeaders",
                typeof(object),
                typeof(MyCustomControl),
                new PropertyMetadata(null, new PropertyChangedCallback(On_RowsHeadersChanged)));

        public object _RowsHeaders
        {
            get { return (object)GetValue(_RowsHeadersProperty); }
            private set { SetValue(_RowsHeadersProperty, value); }
        }
        private static void On_RowsHeadersChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl UserControl1Control = d as MyCustomControl;
            UserControl1Control.On_RowsHeadersChanged(e);
        }

        private void On_RowsHeadersChanged(DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion
        //Styles
        #region _Style_ItemTemplate
        public static readonly DependencyProperty _Style_ItemTemplateProperty =
            DependencyProperty.Register(
                "_Style_ItemTemplate", 
                typeof(DataTemplate), 
                typeof(MyCustomControl), 
                new PropertyMetadata(null, new PropertyChangedCallback(On_Style_ItemTemplateChanged)));

        public DataTemplate _Style_ItemTemplate
        {
            get { return (DataTemplate)GetValue(_Style_ItemTemplateProperty); }
            set { SetValue(_Style_ItemTemplateProperty, value); }
        }

        private static void On_Style_ItemTemplateChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
         
        }
        #endregion
        #region _Style_HeaderTemplate
        public static readonly DependencyProperty _Style_HeaderTemplateProperty =
            DependencyProperty.Register(
                "_Style_HeaderTemplate", 
                typeof(DataTemplate), 
                typeof(MyCustomControl), 
                new PropertyMetadata(null, new PropertyChangedCallback(On_Style_HeaderTemplateChanged)));

        public DataTemplate _Style_HeaderTemplate
        {
            get { return (DataTemplate)GetValue(_Style_HeaderTemplateProperty); }
            set { SetValue(_Style_HeaderTemplateProperty, value); }
        }

        private static void On_Style_HeaderTemplateChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion

        //Commands
        #region Commands
        public ICommand _CommandSelectAll { get; private set; }
        public ICommand _CommandSelectColumn { get; private set; }
        public ICommand _CommandSelectRow { get; private set; }
        public ICommand _CommandSelectedBiomaterial { get; private set; }

        private void SetCommands()
        {
            _CommandSelectAll = new RelayCommand(obj => SelectAll(obj));
            _CommandSelectColumn = new RelayCommand(obj => SelectColumn(obj));
            _CommandSelectRow = new RelayCommand(obj => SelectRow(obj));
            _CommandSelectedBiomaterial = new RelayCommand(obj => SelectedBiomaterial(obj));
        }

        private void SelectedBiomaterial(object obj)
        {
            var values = (object[])obj;

            ReactionBlockCell currentCell = values.FirstOrDefault(q => q.GetType() == typeof(ReactionBlockCell)) as ReactionBlockCell;
            ValueDescription biomaterial = values.FirstOrDefault(q => q.GetType() == typeof(ValueDescription)) as ValueDescription;

            if(currentCell != null && biomaterial!=null)
                currentCell.Biomaterial = (Biomaterials)biomaterial.Value;
        }


        private void SelectRow(object row)
        {
            var r = (char)row - 65 + 1;
            var allIsSelected = _Items.Where(q => ((ReactionBlockCell)q).Row == r).All(q => ((ReactionBlockCell)q).IsSelected == true);
            _Items.Where(q => ((ReactionBlockCell)q).Row == r).Select(q => ((ReactionBlockCell)q).IsSelected = !allIsSelected).ToList();
        }

        private void SelectColumn(object column)
        {
            var c = int.Parse(column.ToString());
            var allIsSelected = _Items.Where(q => ((ReactionBlockCell)q).Column == c).All(q => ((ReactionBlockCell)q).IsSelected == true);
            _Items.Where(q => ((ReactionBlockCell)q).Column == c).Select(q => ((ReactionBlockCell)q).IsSelected = !allIsSelected).ToList();
        }

        private void SelectAll(object obj)
        {
            var allIsSelected = _Items.All(q => ((ReactionBlockCell)q).IsSelected == true);
            _Items.Select(q => ((ReactionBlockCell)q).IsSelected = !allIsSelected).ToArray();
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
