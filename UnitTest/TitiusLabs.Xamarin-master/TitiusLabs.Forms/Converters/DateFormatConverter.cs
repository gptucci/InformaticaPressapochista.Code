using System;
using Xamarin.Forms;
using System.Collections;
using System.Linq;
using System.Globalization;

namespace TitiusLabs.Forms.Converters
{
	public class DateFormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) return "";

			DateTime d;
			if (DateTime.TryParse(value.ToString(), out d))
			{
				var format = "dd/MM/yyyy";
				if (parameter != null)
					format = parameter.ToString();
				return d.ToString(format);
			}

			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
