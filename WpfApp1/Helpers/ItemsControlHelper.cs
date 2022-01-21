using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.CustomControls;

namespace WpfApp1.Helpers
{
    public class ItemsControlHelper : DependencyObject
    {
        public static readonly DependencyProperty RowsProperty =
        DependencyProperty.RegisterAttached(
        "Rows",
        typeof(string),
        typeof(ReactionBlockCustomControl),
        new PropertyMetadata(null, OnValueChanged));

        public static readonly DependencyProperty ColumnsProperty =
        DependencyProperty.RegisterAttached(
        "Columns",
        typeof(string),
        typeof(ReactionBlockCustomControl));

        public static void SetRows(UIElement element, string value)
        {
            element.SetValue(RowsProperty, value);
        }

        public static void SetColumns(UIElement element, string value)
        {
            element.SetValue(ColumnsProperty, value);
        }

        public static string GetRows(UIElement element)
        {
            return (string)element.GetValue(RowsProperty);
        }

        public static string GetColumns(UIElement element)
        {
            return (string)element.GetValue(ColumnsProperty);
        }

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var result = args.NewValue?.ToString();
        }
    }
}
