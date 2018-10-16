//CODE HELP FROM: https://stackoverflow.com/questions/6501970/how-to-boolean-two-visibility-converters

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RaceRegQuickExample.ViewModel
{
    class MultiBoolToVisConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool visible = true;
            foreach(object value in values)
            {
                if(value is bool)
                {
                    visible = visible && (bool)value;
                }
            }

            if(visible)
            {
                return System.Windows.Visibility.Visible;
            }
            else
            {
                return System.Windows.Visibility.Hidden;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
