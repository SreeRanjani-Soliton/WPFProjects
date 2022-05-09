using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace EmployeeForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog PhotoSelection = new OpenFileDialog();
        Employee employee;
        public MainWindow()
        {
            InitializeComponent();
            employee = new Employee();
            EmployeeDetails.DataContext = employee;
        }

        private void ImgBrowse_Click(object sender, RoutedEventArgs e)
        {
            PhotoSelection.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (PhotoSelection.ShowDialog() == true)
            {
                imgPath.Text = PhotoSelection.FileName;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{employee.Name}\nAddress: {employee.Address}\nPhoto Path: {employee.PhotoPath}\nGender: {employee.Gender}\nMarried: {employee.IsMarried}\nPhone Number: {employee.PhoneNumber}\nMaild Id: {employee.EmailID}" +
                $"\nPosition: {employee.Position}\nProjects: {employee.Projects}\nReport To: {employee.ReportsTo}","Employee Information to Display", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
        public UInt64 PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string Position { get; set; }
        public string Projects { get; set; }
        public string ReportsTo { get; set; } 
    }

    public class EmailIDRule : ValidationRule
    {
        static Regex mailIDPattern;
        static EmailIDRule()
        {
            //Create a RegEx pattern for mail ID 
            mailIDPattern = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase);
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            /*
            // Test if date is valid
            if (DateTime.TryParse(value.ToString(), out DateTime date))
            {
                // Date is not in the future, fail
                if (DateTime.Now > date)
                    return new ValidationResult(false, "Please enter a date in the future.");
            }
            else
            {
                // Date is not a valid date, fail
                return new ValidationResult(false, "Value is not a valid date.");
            }

            // Date is valid and in the future, pass
            return ValidationResult.ValidResult;
            */
            bool isMailID = mailIDPattern.IsMatch(value.ToString());
            if(!isMailID)
            {
                return new ValidationResult(false, "Input is not a valid email ID");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }

    public class PhoneNumberRule : ValidationRule
    {
        static Regex phoneNumPattern;
        static PhoneNumberRule()
        {
            //Create a RegEx pattern for mail ID 
            phoneNumPattern = new Regex(@"^[0-9]{10}$", RegexOptions.IgnoreCase);
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool isPhoneNum = phoneNumPattern.IsMatch(value.ToString());
            if (!isPhoneNum)
            {
                return new ValidationResult(false, "Input is not a valid phone number");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }

    class radioBoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string gender = (string)value;
            if(gender == parameter.ToString())
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
            return parameter.ToString();
        }
    }

}
