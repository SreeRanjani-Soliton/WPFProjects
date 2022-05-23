using EmployeeManagement;
using EmployeeManagement.ViewModel.Helper;
using EmployeeManagementMVVM.Model;
using EmployeeManagementMVVM.ViewModel;
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

namespace EmployeeManagementMVVM.View
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        OpenFileDialog ImageSelection = new OpenFileDialog();
        public EmployeeForm()
        {
            InitializeComponent();
            Loaded += EmployeeForm_Loaded;
            //Setting this window to open at the center of the owner
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        //Adding an event for closing the form - CloseWindowEvent is declared in the EmployeeFormViewModel
        private void EmployeeForm_Loaded(object sender, RoutedEventArgs eventArgs)
        {
            //Checking if the data context is EmployeeFormViewModel
            if(DataContext is ICloseWindows vm)
            {
                vm.CloseWindowEvent += (s, e) => this.Close();
            }
        }
    }

}
