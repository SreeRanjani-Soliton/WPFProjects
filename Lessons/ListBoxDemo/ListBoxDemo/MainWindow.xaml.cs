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

namespace ListBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbwDataTemplate.ItemsSource = new List<FruitData>{
                new FruitData(){name="Apple",imgUrl="https://toppng.com/uploads/preview/apple-fruit-11526067113bpkdzjmq8g.png"},
                new FruitData(){name="Orange",imgUrl="https://cdn.pixabay.com/photo/2016/02/23/17/42/orange-1218158_960_720.png"},
                new FruitData(){name="Guava",imgUrl="https://pngimg.com/uploads/guava/guava_PNG59.png"}

            };
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            ListBoxItem lbi = lb.SelectedItem as ListBoxItem;
            string tb = lbi.Content as string;
            MessageBox.Show("Selected Option is \"" + tb +"\"");
        }

    }

    class FruitData
    {
        public string name { get; set; }
        public string imgUrl { get; set; }
    }
}
