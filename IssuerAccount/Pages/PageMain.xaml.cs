using IssuerAccount.Model;
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
using IssuerAccount.Pages;
using System.Collections.ObjectModel;

namespace IssuerAccount.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public Issuer Issuer { get; set; }
        public PageMain(Issuer issuer)
        {
            int i = 1;
            InitializeComponent();
            Issuer = issuer;
            this.DataContext = this;
            if (issuer.Id_Account != null)
            {
                statusImage.Source = new BitmapImage(new Uri("/IssuerAccount;component/Resourses/galka.png", UriKind.Relative));
                statusText.Text = "Счёт открыт, ваш баланс:";
            }
            else
            {
                statusImage.Source = new BitmapImage(new Uri("/IssuerAccount;component/Resourses/crest.png", UriKind.Relative));
                statusText.Text = "У вас нет открытого счёта";
                openAccount.Visibility = Visibility.Visible;
            }
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInvestors_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void img_prod_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PagePersonalAccount(Issuer));
        }

        private void btnSecurity_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageSecurityList(Issuer));
        }
    }
}
