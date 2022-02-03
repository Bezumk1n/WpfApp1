using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using WpfApp1.Helpers;
using static WpfApp1.Helpers.EnumHelper;

namespace WpfApp1.Converters
{
    [ValueConversion(typeof(Enum), typeof(IEnumerable<ValueDescription>))]
    public class EnumToCollectionConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = EnumHelper.GetAllValuesAndDescriptions(value.GetType());
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
