using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TreeViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MenuItem root = new MenuItem { Title = "Root" };
            MenuItem child1 = new MenuItem { Title = "Child1" };
            child1.Items.Add(new MenuItem { Title = "Child11" });
            child1.Items.Add(new MenuItem { Title = "Child12" });
            root.Items.Add(child1);
            root.Items.Add(new MenuItem { Title = "Child2" });
            trvMenu.Items.Add(root);

        }
    }

    public class MenuItem
    {
        public MenuItem()
        {
            Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }

        public ObservableCollection<MenuItem> Items{ get; set; }
    }
}
