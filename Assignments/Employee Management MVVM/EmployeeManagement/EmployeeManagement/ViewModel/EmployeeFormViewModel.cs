using EmployeeManagement;
using EmployeeManagement.ViewModel.Helper;
using EmployeeManagementMVVM.Command;
using EmployeeManagementMVVM.Model;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementMVVM.ViewModel
{
    public class EmployeeFormViewModel : INotifyPropertyChanged, ICloseWindows
    {
        #region Fields
        private Employee _employee;
        private RelayCommand _imgBrowseCommand;
        private OpenFileDialog _imgSelection = new OpenFileDialog();
        private RelayCommand _addEmployeeCommand;
        private RelayCommand _cancelCommand;
        #endregion

        #region Constructor
        public EmployeeFormViewModel()
        {
            Employee = new Employee();
        }
        #endregion

        #region Properties 
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                //NotifyPropertyChanged("Employee");
            }
        }

        //Command Properties
        public RelayCommand ImageBrowseCommand
        {
            get
            {
                if (_imgBrowseCommand == null)
                {
                    _imgBrowseCommand = new RelayCommand(browseForImage);
                }
                return _imgBrowseCommand;
            }
            private set { _imgBrowseCommand = value; }
        }

        public RelayCommand AddEmployeeCommand
        {
            get
            {
                if (_addEmployeeCommand == null)
                {
                    _addEmployeeCommand = new RelayCommand(addEmployee,canAddEmployee);
                }
                return _addEmployeeCommand;
            }
            private set { _addEmployeeCommand = value; }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(closeWindow);
                }
                return _cancelCommand;
            }
            private set { _cancelCommand = value; }
        }
        #endregion

        #region HelperFunctions
        /// <summary>
        /// This method is used to add employee
        /// </summary>
        /// <param name="parameter">Optional parameter, added to work with relay commands</param>
        private void addEmployee(object parameter)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DBPath))
            {
                //Create SQLite table if not present
                connection.CreateTable<Employee>();
                connection.Insert(_employee);
            }
            //MessageBox.Show(_employee.ToString());
            closeWindow(parameter);
        }

        /// <summary>
        /// This method is used for notifying if the Add button in form can be enabled or disabled
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool canAddEmployee(object obj)
        {
            if (String.IsNullOrEmpty(Employee.Name) || String.IsNullOrEmpty(Employee.Address) || String.IsNullOrEmpty(Employee.PhoneNumber) || String.IsNullOrEmpty(Employee.EmailID) || String.IsNullOrEmpty(Employee.Project) || String.IsNullOrEmpty(Employee.ReportsTo) || string.IsNullOrEmpty(Employee.Gender))
            {
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// This method is used to show popup for browsing and selecting image. This will refect in the UI because of INotifyPropertyChange
        /// </summary>
        /// <param name="parameter">Optional parameter, added to work with relay commands</param>
        private void browseForImage(object parameter)
        {
            _imgSelection.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            //Show File selection dialog, if user selected a file it returns true 
            if (_imgSelection.ShowDialog() == true)
            {
                //Set employee.PhotoPath to the selected value. 
                _employee.PhotoPath = _imgSelection.FileName;
                //Employee = _employee;
                //NotifyPropertyChanged("Employee");
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Handling closing of window on Cancel
        /// </summary>
        public event EventHandler CloseWindowEvent;

        private void closeWindow(object optionalParameter)
        {
            CloseWindowEvent?.Invoke(this, EventArgs.Empty);
        }
        #endregion

    }
}
