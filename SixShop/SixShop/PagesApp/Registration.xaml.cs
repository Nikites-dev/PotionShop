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

namespace SixShop.PagesApp
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            

            if(EdName.Text != "" && EdLogin.Text != "" && EdPassword.Password != "" && EdRole.Text != "")
            {
                if(App.Connection.Authorization.Where(x => x.Login == EdLogin.Text).FirstOrDefault() == null)
                {
                    User user = new User();

                    user.Name = EdName.Text;
                    

                    if(EdRole.Text == "Гость" || EdRole.Text == "гость")
                    {
                        user.IdRole = 1;
                    }

                    else if (EdRole.Text == "Покупатель" || EdRole.Text == "покупатель")
                    {
                        user.IdRole = 2;
                    }

                    else if (EdRole.Text == "Администратор" || EdRole.Text == "администратор")
                    {
                        user.IdRole = 3;
                    }

                    else if (EdRole.Text == "Кладовщик" || EdRole.Text == "кладовщик")
                    {
                        user.IdRole = 4;
                    }

                    else if (EdRole.Text == "Контрагент" || EdRole.Text == "контрагент")
                    {
                        user.IdRole = 5;
                    }

                    App.Connection.User.Add(user);
                    App.Connection.SaveChanges();


                    SixShop.ADOApp.Authorization auth = new ADOApp.Authorization();

                    auth.Login = EdLogin.Text;
                    auth.Password = EdPassword.Password;
                    auth.IdUser = user.IdUser;

                    App.Connection.Authorization.Add(auth);
                    App.Connection.SaveChanges();

                    MessageBox.Show("succes!");
                    
                }
            }


            


        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
