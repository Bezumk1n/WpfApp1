using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.CustomControls
{
    public partial class MyCustomControl
    {
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
           name: "_ColumnsHeaders",
          propertyType: typeof(IEnumerable<object>),
          ownerType: typeof(MyCustomControl),
          new PropertyMetadata(null, new PropertyChangedCallback(On_ColumnsHeadersChanged)));

        public IEnumerable<object> _ColumnsHeaders
        {
            get { return (IEnumerable<object>)GetValue(_ColumnsHeadersProperty); }
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
            //tbTest.Text = e.NewValue.ToString();
        }
        #endregion
        #region _RowsHeaders
        public static readonly DependencyProperty _RowsHeadersProperty =
       DependencyProperty.Register(
           name: "_RowsHeaders",
          propertyType: typeof(IEnumerable<char>),
          ownerType: typeof(MyCustomControl),
          new PropertyMetadata(null, new PropertyChangedCallback(On_RowsHeadersChanged)));

        public IEnumerable<char> _RowsHeaders
        {
            get { return (IEnumerable<char>)GetValue(_RowsHeadersProperty); }
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
            //tbTest.Text = e.NewValue.ToString();
        }
        #endregion
        //Index
        #region _IsGenerateCellIndex
        public static readonly DependencyProperty _IsGenerateCellIndexProperty =
       DependencyProperty.Register("_IsGenerateCellIndex", typeof(bool), typeof(MyCustomControl), new
          PropertyMetadata(false, new PropertyChangedCallback(On_IsGenerateCellIndexChanged)));

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
            //tbTest.Text = e.NewValue.ToString();
        }
        #endregion
        //Reaction plate
        #region __RowCount
        public static readonly DependencyProperty _RowCountProperty =
       DependencyProperty.Register("_RowCount", typeof(int), typeof(MyCustomControl), new
          PropertyMetadata(0, new PropertyChangedCallback(On_RowCountChanged)));

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
            //tbTest.Text = e.NewValue.ToString();
        }
        #endregion
        #region _ColumnCount
        public static readonly DependencyProperty _ColumnCountProperty =
       DependencyProperty.Register("_ColumnCount", typeof(int), typeof(MyCustomControl), new
          PropertyMetadata(0, new PropertyChangedCallback(On_ColumnCountChanged)));

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
            //tbTest.Text = e.NewValue.ToString();
        }
        #endregion
        #region _Items
        public static readonly DependencyProperty _ItemsProperty =
       DependencyProperty.Register(
           name: "_Items",
          propertyType: typeof(IEnumerable<object>),
          ownerType: typeof(MyCustomControl),
          new PropertyMetadata(null, new PropertyChangedCallback(On_ItemsChanged)));

        public IEnumerable<object> _Items
        {
            get { return (IEnumerable<object>)GetValue(_ItemsProperty); }
            set { SetValue(_ItemsProperty, value); }
        }
        private static void On_ItemsChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl UserControl1Control = d as MyCustomControl;
            var step = UserControl1Control._ColumnCount;
            if (step <= 0)
                return;
            var items = (IEnumerable<object>)e.NewValue;
            var count = items.Count();
            var currentIndex = 0;
            var list = new List<List<object>>();

            if (UserControl1Control._RowCount * UserControl1Control._ColumnCount > count)
            {
                //throw new Exception("Reaction plate - Invalid cells count");
                return;
            }
            while (currentIndex < count)
            {
                var part = items.Skip(currentIndex).Take(step).ToArray();
                var row = new List<object>(part);
                list.Add(row);
                currentIndex += step;
            }
            UserControl1Control._ItemCells = list;
            //Headers
            if (UserControl1Control._IsGenerateHeaders)
            {
                var columnsHeaders = new List<string>();
                for (int i = 1; i <= UserControl1Control._ColumnCount; i++)
                    columnsHeaders.Add(i.ToString("00"));
                UserControl1Control._ColumnsHeaders = columnsHeaders.ToArray();

                var rowsHeaders = "";
                for (int i = 0; i < UserControl1Control._RowCount; i++)
                {
                    var c = (char)(65 + i);
                    rowsHeaders += c;
                }
                UserControl1Control._RowsHeaders = rowsHeaders;
            }
            else
            {
                UserControl1Control._ColumnsHeaders = null;
                UserControl1Control._RowsHeaders = null;
            }

            UserControl1Control.On_ItemsChanged(e);
        }

        private void On_ItemsChanged(DependencyPropertyChangedEventArgs e)
        {
            //tbTest.Text = e.NewValue.ToString();
        }
        #endregion
        #region _ItemCells
        public static readonly DependencyProperty _ItemCellsProperty =
      DependencyProperty.Register(
          name: "_ItemCells",
         propertyType: typeof(IEnumerable<IEnumerable<object>>),
         ownerType: typeof(MyCustomControl),
         new PropertyMetadata(null, new PropertyChangedCallback(On_ItemCellsChanged)));

        public IEnumerable<IEnumerable<object>> _ItemCells
        {
            get { return (IEnumerable<IEnumerable<object>>)GetValue(_ItemCellsProperty); }
            private set { SetValue(_ItemCellsProperty, value); }
        }
        private static void On_ItemCellsChanged(DependencyObject d,
          DependencyPropertyChangedEventArgs e)
        {
            MyCustomControl control = d as MyCustomControl;
            control.On_ItemsChanged(e);
        }
        private void On_ItemCellsChanged(DependencyPropertyChangedEventArgs e)
        {
            //tbTest.Text = e.NewValue.ToString();
        }
        #endregion
        //Styles
        #region _Style_ItemTemplate
        public static readonly DependencyProperty _Style_ItemTemplateProperty =
       DependencyProperty.Register("_Style_ItemTemplate", typeof(DataTemplate), typeof(MyCustomControl), new
          PropertyMetadata(null, new PropertyChangedCallback(On__Style_ItemTemplateChanged)));

        public DataTemplate _Style_ItemTemplate
        {
            get { return (DataTemplate)GetValue(_Style_ItemTemplateProperty); }
            set { SetValue(_Style_ItemTemplateProperty, value); }
        }

        private static void On__Style_ItemTemplateChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
         
        }
        #endregion
        #region _Style_HeaderTemplate
        public static readonly DependencyProperty _Style_HeaderTemplateProperty =
       DependencyProperty.Register("_Style_HeaderTemplate", typeof(DataTemplate), typeof(MyCustomControl), new
          PropertyMetadata(null, new PropertyChangedCallback(On__Style_HeaderTemplateChanged)));

        public DataTemplate _Style_HeaderTemplate
        {
            get { return (DataTemplate)GetValue(_Style_HeaderTemplateProperty); }
            set { SetValue(_Style_HeaderTemplateProperty, value); }
        }

        private static void On__Style_HeaderTemplateChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion
        #region _Style_SelectAllTemplate
        public static readonly DependencyProperty _Style_SelectAllTemplateProperty =
       DependencyProperty.Register("_Style_SelectAllTemplate", typeof(Label), typeof(MyCustomControl), new
          PropertyMetadata(null, new PropertyChangedCallback(On__Style_SelectAllTemplateChanged)));

        public Label _Style_SelectAllTemplate
        {
            get { return (Label)GetValue(_Style_SelectAllTemplateProperty); }
            set { SetValue(_Style_SelectAllTemplateProperty, value); }
        }

        private static void On__Style_SelectAllTemplateChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion
    }
}
