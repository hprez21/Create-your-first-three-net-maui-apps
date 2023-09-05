using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiibopediaDemo.Converters
{
    public class RandomBackgroundConverter : IValueConverter
    {
        Random random = new Random();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte red = (byte)random.Next(0, 128);
            byte green = (byte)random.Next(0, 128);
            byte blue = (byte)random.Next(0, 128);

            return new Color(red / 255.0f, green / 255.0f, blue / 255.0f);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
