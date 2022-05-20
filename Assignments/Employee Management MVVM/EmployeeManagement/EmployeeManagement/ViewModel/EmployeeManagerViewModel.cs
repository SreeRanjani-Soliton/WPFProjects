using EmployeeManagement.Command;
using EmployeeManagement.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeManagerViewModel: INotifyPropertyChanged
    {
        #region Properties

        //Commands
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

        private RelayCommand _deleteEmployeeCommand;

        public RelayCommand DeleteEmployeeCommand
        {
            get
            {
                if (_deleteEmployeeCommand == null)
                {
                    _deleteEmployeeCommand = new RelayCommand(deleteEmployee);
                }
                return _deleteEmployeeCommand;
            }
            set { _deleteEmployeeCommand = value; }
        }

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

        public object EmployeeListView { get; private set; }
        #endregion

        #region Helper Methods
        private void addEmployee(object obj)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.ShowDialog();
            readDB();
        }

        private void deleteEmployee(object obj)
        {
            Employee selEmployee = obj as Employee;
            if (selEmployee == null)
            {
                MessageBox.Show($"Please select an item", "Delete Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Constructor
        public EmployeeManagerViewModel()
        {
            readDB();
        }
        #endregion
    }

}
