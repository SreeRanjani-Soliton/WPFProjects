using DesktopContactApp.Classes;
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

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            contacts = new List<Contact>();

            //Read the content from database when a the window is launched
            ReadDatabase();
        }

        private void newContactButton_Click(object sender, RoutedEventArgs e)
        {
            //#TODO Check how to create the window only once and use it multiple times. Key here is to make sure the window is empty whenever opened
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDatabase();

            //Read the content from database whenever the content is updated
        }


        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //getting text box ref
            TextBox searchTextBox = sender as TextBox;
            //Filtering contacts with case insensitivity. Where is an extended method of List added by LINQ
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            /* (c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList(); is equivalent to writing the below database query in LINQ
               var contacts = (from c in contacts
                              where c.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                              select c).ToList();

            if we want name/ id only we can do as below using LINQ
            (c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList(); is equivalent to writing the below database query in LINQ
               var contacts = (from c in contacts
                              where c.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                              select c.Name).ToList();
            */
            ContactListView.ItemsSource = filteredList;
        }

       
        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selContact = (Contact)ContactListView.SelectedItem;

            //This selection is getting triggered on update or delete and selectedItem becomes null
            if (selContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selContact);
                contactDetailsWindow.ShowDialog();
                ReadDatabase();
            }
        }

        private void ReadDatabase()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DBPath))
            {
                //Creates a table when table is not already present
                connection.CreateTable<Contact>();
                // connection.Table<Contact> - gives a query this is not readable hence converting it to a list
                contacts = connection.Table<Contact>().ToList();
                // sorting alphabetically. OrderBy is is an extended method of List added by LINQ
                contacts = contacts.OrderBy(c => c.Name).ToList();

                /* (c=>c.Name); is equivalent to writing the below database query in LINQ
                   var contacts = from c in contacts
                                  orderby c.Name
                                  select c;
                */
            }

            if (contacts != null)
            {
                //to string property will be applied to every element in the contact and mapped to the item source
                ContactListView.ItemsSource = contacts;
            }
        }
    }
}
