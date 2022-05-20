using EmployeeManagement.Model;
using SQLite;
using System;
using System.Collections.Generic;
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

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //readDBAndUpdateUI();

        }

       private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.ShowDialog();
            //readDBAndUpdateUI();
        }


        private void readDBAndUpdateUI()
        {
            //using (SQLiteConnection connection = new SQLiteConnection(App.DBPath))
            //{
            //    connection.CreateTable<Employee>();
            //    var emplyoees = connection.Table<Employee>().ToList();
            //    if (emplyoees != null)
            //    {
            //        //to string property will be applied to every element in the contact and mapped to the item source
            //        EmployeeListView.ItemsSource = emplyoees;
            //    }
            //}
        }

        //private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        //{
        //    Employee selEmployee = (Employee)EmployeeListView.SelectedItem;
        //    if(selEmployee == null)
        //    {
        //       MessageBox.Show($"Please select an item", "Delete Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //    else
        //    {
        //        MessageBoxResult userResponse = MessageBox.Show($"Do you want to delete the selected employee's details", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        //        if (userResponse == MessageBoxResult.Yes)
        //        {
        //            using (SQLiteConnection connection = new SQLiteConnection(App.DBPath))
        //            {
        //                //Create table if not already present to avoid errors
        //                connection.CreateTable<Employee>();
        //                connection.Delete(selEmployee);
        //                readDBAndUpdateUI();
        //            }
        //        }
        //    }
            
        //}

        //private void EmployeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Employee selEmployee = EmployeeListView.SelectedItem as Employee;
        //    //selEmpDetails.DataContext = selEmployee;
        //}
    }
}
