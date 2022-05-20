using EmployeeManagement.Model;
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
        OpenFileDialog ImageSelection = new OpenFileDialog();
        Employee employee;
        public EmployeeForm()
        {
            InitializeComponent();
            //Owner = Application.Current.MainWindow;
            //WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //employee = new Employee() {IsMarried="Single"};
            //EmployeeDetails.DataContext = employee;
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

    public class RadioConverter : IValueConverter
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
            return parameter.ToString();
        }
    }



}
