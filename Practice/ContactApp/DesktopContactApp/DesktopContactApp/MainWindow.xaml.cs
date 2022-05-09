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
        public MainWindow()
        {
            InitializeComponent();

            //Read the content from database when a the window is launched
            ReadDatabase();
        }

        private void newContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDatabase();

            //Read the content from database whenever the content is updated
        }


        private void ReadDatabase()
        {
            List<Contact> contacts = new List<Contact>();
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DBPath))
            {
                //Creates a table when table is not already present
                connection.CreateTable<Contact>();
                // connection.Table<Contact> - gives a query this is not readable
                contacts = connection.Table<Contact>().ToList();
            }

            if(contacts != null)
            {
                ContactListView.ItemsSource = contacts;
            }
        }

    }
}
