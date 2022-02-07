using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfApp1.Helpers
{
    public class BindingProxy : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        public object DataContext
        {
            get { return (object)GetValue(DataContextProperty); }
            set { SetValue(DataContextProperty, value); }
        }

        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register("DataContext", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
}
