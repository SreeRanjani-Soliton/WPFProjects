using DesktopContactApp.Classes;
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
using System.Windows.Shapes;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {

        Contact selContact; 
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            //App.XAML has startup URI as MainWindow, that is used here
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;   
            selContact = contact;
            ContactDetails.DataContext = selContact;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DBPath))
            {
                
                //Creates a table if not already present
                connection.CreateTable<Contact>();
                connection.Update(selContact);
            }
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //Deleting a contact to the SQLite database
            //using statements can be used if a class implements IDisposable interface
            using (SQLiteConnection connection = new SQLiteConnection(App.DBPath))
            {
                //Creates a table if not already present
                connection.CreateTable<Contact>();
                connection.Delete(selContact);
            }
            this.Close();
        }
    }
}
