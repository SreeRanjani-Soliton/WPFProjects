using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EmployeeManagementMVVM.ViewModel.Helper
{   
    /// <summary>
    /// Class to handle gender radio button value to string conversion
    /// </summary>
    class genderRadioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string gender = (string)value;
            if (gender == parameter.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //bool ctGender = System.Convert.ToBoolean(value);
            //return parameter.ToString();
            if ((bool)value)
                return parameter;

            return Binding.DoNothing;
        }
    }

    /// <summary>
    /// Class to handle married check box to string conversion
    /// </summary>
    class marriedStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string marriedStatus = (string)value;
            if (marriedStatus == "Married")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string marriedStatus = ((bool)value) ? "Married" : "Single";
            return marriedStatus;
        }
    }
}
