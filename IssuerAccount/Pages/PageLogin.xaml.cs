using IssuerAccount.Model;
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

namespace IssuerAccount.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public static ObservableCollection<Issuer> issuers { get; set; }
        public PageLogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            issuers = new ObservableCollection<Issuer>(db_connection.connection.Issuer.ToList());
            var z = issuers.Where(a => a.Login == tbLogin.Text && a.Password == pbPassword.Password).FirstOrDefault();
            if (z != null)
            {
                MessageBox.Show("Добро пожаловать, " + z.FullName);
                NavigationService.Navigate(new PageMain(z));
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRegistration());
        }
    }
}
