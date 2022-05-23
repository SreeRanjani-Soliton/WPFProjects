using EmployeeManagement;
using EmployeeManagementMVVM.Command;
using EmployeeManagementMVVM.Model;
using EmployeeManagementMVVM.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementMVVM.ViewModel
{
    public class EmployeeManagerViewModel: INotifyPropertyChanged
    {
        #region Constructor
        public EmployeeManagerViewModel()
        {
            readDB();
        }
        #endregion

        #region Properties
        //Other Properties
        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                NotifyPropertyChanged("Employees");
            }
        }

        //Command
        //Add Employee Command
        private RelayCommand _addEmployeeCommand;
        public RelayCommand AddEmployeeCommand
        {
            get
            {
                if(_addEmployeeCommand == null)
                {
                    _addEmployeeCommand = new RelayCommand(addEmployee);
                }
                return _addEmployeeCommand;
            }
            private set{_addEmployeeCommand = value;}
        }

        //Delete Employee Command
        private RelayCommand _deleteEmployeeCommand;
        public RelayCommand DeleteEmployeeCommand
        {
            get
            {
                if (_deleteEmployeeCommand == null)
                {
                    _deleteEmployeeCommand = new RelayCommand(deleteEmployee,canDeleteEmployee);
                }
                return _deleteEmployeeCommand;
            }
            set { _deleteEmployeeCommand = value; }
        }

        //public object EmployeeListView { get; private set; }
        #endregion

        #region HelperMethods
        private void addEmployee(object obj)
        {
            //EmployeeForm employeeForm = new EmployeeForm();
            //employeeForm.ShowDialog();
            ShowAddEmployeeWindow();
            readDB();
        }

        private void deleteEmployee(object obj)
        {
            Employee selEmployee = obj as Employee;
                MessageBoxResult userResponse = MessageBox.Show($"Do you want to delete the selected employee's details", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (userResponse == MessageBoxResult.Yes)
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.DBPath))
                {
                    //Create table if not already present to avoid errors
                    connection.CreateTable<Employee>();
                    connection.Delete(selEmployee);
                    readDB();
                }
            }
        }

        private bool canDeleteEmployee(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
                return true;
        }

        private void readDB()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DBPath))
            {
                connection.CreateTable<Employee>();
                var emplyoees = connection.Table<Employee>().ToList();
                if (emplyoees != null)
                {
                    //to string property will be applied to every element in the contact and mapped to the item source
                    Employees = new ObservableCollection<Employee>(emplyoees);
                }
            }  
        }
        #endregion

        #region Events
        //Event for handling property change between object and UI
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Event to launch window to add employee
        public event EventHandler AddEmployeeWindowEvent;
        private void ShowAddEmployeeWindow()
        {
            AddEmployeeWindowEvent?.Invoke(this, EventArgs.Empty);
        }
        #endregion

    }

}
