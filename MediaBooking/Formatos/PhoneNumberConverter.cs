using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBooking.Formatos
{
    class PhoneNumberConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            string phoneNumber = value.ToString();
            if (phoneNumber.Length == 10)
            {
                return string.Format("({0})-{1}-{2}", phoneNumber.Substring(0, 3), phoneNumber.Substring(3, 3), phoneNumber.Substring(6, 4));
            }
            else
            {
                return phoneNumber; // Si el número de teléfono no tiene 10 dígitos, devolverlo sin cambios
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
