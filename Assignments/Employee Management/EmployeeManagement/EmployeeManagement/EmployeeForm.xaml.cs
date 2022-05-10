using EmployeeManagement.Classes;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        OpenFileDialog PhotoSelection = new OpenFileDialog();
        Employee employee;
        public EmployeeForm()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            employee = new Employee() {IsMarried="Single"};
            EmployeeDetails.DataContext = employee;
        }

        private void ImgBrowse_Click(object sender, RoutedEventArgs e)
        {
            PhotoSelection.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (PhotoSelection.ShowDialog() == true)
            {
                imgPath.Text = PhotoSelection.FileName;
                employee.PhotoPath = PhotoSelection.FileName;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DBPath))
            {
                //Create SQLite table if not present
                connection.CreateTable<Employee>();
                connection.Insert(employee);
            }
            this.Close();
           // MessageBox.Show($"{employee.Name}\nAddress: {employee.Address}\nPhoto Path: {employee.PhotoPath}\nGender: {employee.Gender}\nMarried: {employee.IsMarried}\nPhone Number: {employee.PhoneNumber}\nMaild Id: {employee.EmailID}" +
           //     $"\nPosition: {employee.Position}\nProjects: {employee.Projects}\nReport To: {employee.ReportsTo}", "Employee Information to Display", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class EmptyInputRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool isEmpty = (value==null|| string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()));
            if (isEmpty)
            {
                return new ValidationResult(false, "Input is not valid");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
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
            bool isMailID = mailIDPattern.IsMatch(value.ToString());
            if (!isMailID)
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
            return parameter.ToString();
        }
    }

    class marriedStatusConverted : IValueConverter
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
