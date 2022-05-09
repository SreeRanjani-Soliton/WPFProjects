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

namespace ListViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
             List<User> users= new List<User>
            {
                new User(){Name="Sree",Age=29,Email="sreeranjani@gamil.com"},
                new User(){Name="Karthik",Age=30,Email="karthik@gamil.com"},
                new User(){Name="Bharanee",Age=25,Email="bharanee@gamil.com"}
            };
            LVDataTemplate.ItemsSource = users;
            LVGridView.ItemsSource = users;
        }
    }

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }
    }
}
