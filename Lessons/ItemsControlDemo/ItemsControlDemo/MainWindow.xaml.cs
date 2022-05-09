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

namespace ItemsControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fruits.ItemsSource = new List<string>
            {
                "Apple","Banana","Mango"
            };
            List<FruitsWithPrice> fruitsWithPrice = new List<FruitsWithPrice>
            {
                new FruitsWithPrice("Apple",120),
                new FruitsWithPrice("Banana",80),
                new FruitsWithPrice("Mango",200)
            };

            fruitsWithPriceUI.ItemsSource = fruitsWithPrice;
            fruits2.ItemsSource = fruitsWithPrice;
        }
    }

    class FruitsWithPrice
    {
        public FruitsWithPrice(string name,double price)
        {
            Name = name;
            Price = price;
        }

        public string Name
        {
            get;set;
        }

        public Double Price
        {
            get; set;
        }
    }
}
