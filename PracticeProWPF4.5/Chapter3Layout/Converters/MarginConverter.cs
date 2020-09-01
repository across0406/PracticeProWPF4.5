using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Chapter3Layout.Converters
{
    public class MarginConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            double margin = System.Convert.ToDouble( value );
            return new Thickness( margin, margin, margin, margin );
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            return null;
        }
    }
}
