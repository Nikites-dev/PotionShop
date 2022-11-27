using SixShop.ADOApp;
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

namespace SixShop.PagesApp
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        public Shop()
        {
            InitializeComponent();
            listTemplate.ItemsSource = App.Connection.Item.ToList();

            
           
            
        }

        private void listTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listTemplate.SelectedItem != null)
            {
                var select = listTemplate.SelectedItem as Item;
                MessageBox.Show(select.Name);
            }
        }
    }
}
