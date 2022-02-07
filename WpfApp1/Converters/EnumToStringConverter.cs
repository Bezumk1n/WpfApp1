﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using WpfApp1.Helpers;

namespace WpfApp1.Converters
{
    public class EnumToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = string.Empty;
            if (value is Enum)
                result = ((Enum)value).Description();
            return result;
        }

        // No need to implement converting back on a one-way binding 
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
