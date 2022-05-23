using EmployeeManagementMVVM.Model;
using EmployeeManagementMVVM.ViewModel;
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

namespace EmployeeManagementMVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeManagerViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Loaded += MainWindow_Loaded;
            /*Alternative method of handling ShowDialog
            viewModel = new EmployeeManagerViewModel();
            this.DataContext = viewModel;
            viewModel.ShowAddEmployeeWindowEvent += (s, e) => new EmployeeForm().ShowDialog();
            */
        }

        //Handling of showing add employee dialog event from VM
        private void MainWindow_Loaded(object sender, RoutedEventArgs eventArgs)
        {
            //Checking if the DataContext is EmployeeManagerViewModel
            if(DataContext is EmployeeManagerViewModel vm)
            {
                vm.AddEmployeeWindowEvent += (s, e) => new EmployeeForm().ShowDialog();
            }
        }

    }
}
