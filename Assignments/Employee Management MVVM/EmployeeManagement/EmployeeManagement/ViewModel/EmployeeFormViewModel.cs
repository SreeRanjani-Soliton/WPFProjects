using EmployeeManagement.Command;
using EmployeeManagement.Model;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeFormViewModel : INotifyPropertyChanged
    {
        private Employee _employee;
        private RelayCommand _imgBrowseCommand;
        private OpenFileDialog _imgSelection = new OpenFileDialog();

        //Properties
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

        private RelayCommand _addEmployeeCommand;

        public RelayCommand AddEmployeeCommand
        {
            get
            {
                if (_addEmployeeCommand == null)
                {
                    _addEmployeeCommand = new RelayCommand(addEmployee);
                }
                return _addEmployeeCommand;
            }
            private set { _addEmployeeCommand = value; }
        }


        //Helper
        /// <summary>
        /// This method is used to show popup for browsing and selecting image. This will refect in the UI because of INotifyPropertyChange
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
            MessageBox.Show(_employee.ToString());
        }


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
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public EmployeeFormViewModel()
        {
            Employee = new Employee();
        }
    }
}
