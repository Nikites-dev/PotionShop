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
using SixShop.ADOApp;
using System.IO;
using Microsoft.Win32;

namespace SixShop.PagesApp
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {

        public byte[] ImageBin { get; set; }

        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (EdLogin.Text != "" && EdPassword.Password != "")
            {
                var auth = App.Connection.Authorization.Where(x => x.Login == EdLogin.Text && x.Password == EdPassword.Password).FirstOrDefault();

                if (auth != null)
                {
                    if (auth.User.IdRole == 3)
                    {
                        NavigationService.Navigate(new Admition());
                    }
                    else
                    {
                        NavigationService.Navigate(new Shop());
                    }
                }
            }
        }



        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }



    }
}
