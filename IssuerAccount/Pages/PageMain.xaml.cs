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
using IssuerAccount.Windows;

namespace IssuerAccount.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public Issuer Issuer { get; set; }
        public AccountOpeningApplication accountOpeningApplication { get; set; }
        public PageMain(Issuer issuer)
        {
            InitializeComponent();
            Issuer = issuer;
            this.DataContext = this;
            if (issuer.Id_Account != null)
            {
                statusImage.Source = new BitmapImage(new Uri("/IssuerAccount;component/Resourses/galka.png", UriKind.Relative));
                statusText.Text = "Ваш счет открыт, баланс:";
                tbbal.Visibility = Visibility.Visible;
                btnTopUpBalance.Visibility = Visibility.Visible;
                sppos.Visibility = Visibility.Visible;

            }
            else
            {
                statusImage.Source = new BitmapImage(new Uri("/IssuerAccount;component/Resourses/crest.png", UriKind.Relative));
                statusText.Text = "У вас нет открытого счёта";
                btnOpenAccount.Visibility = Visibility.Visible;
                sppos.Visibility = Visibility.Hidden;
            }
        }
        private void btnDeal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageYourDeals(Issuer));
        }

        private void img_prod_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PagePersonalAccount(Issuer));
        }

        private void btnSecurity_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageSecurityList(Issuer));
        }

        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            IssuerAccount.Windows.ConfirmationWindow confirmationWindow = new IssuerAccount.Windows.ConfirmationWindow(); // Создание экземпляра окна ConfirmationWindow
            confirmationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            confirmationWindow.ShowDialog(); 



            if (confirmationWindow.isConfirmed)
            {
                var a = new AccountOpeningApplication();
                a.Id_Issuer = Issuer.Id;
                a.RegistrationStatus = false;
                a.DateOfApplication = DateTime.Now;
                db_connection.connection.AccountOpeningApplication.Add(a);
                db_connection.connection.SaveChanges();
                MessageBox.Show("Ваша заявка успешно создана, ожидайте подтверждения");

            }
            else
            {
            }
        }

        private void btnTopUpBalance_Click(object sender, RoutedEventArgs e)
        {
            sppos.Visibility = Visibility.Hidden;
            sptu.Visibility = Visibility.Visible;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            var Account = db_connection.connection.Account.FirstOrDefault(q => q.Id == Issuer.Id_Account);
            Account.Balance = Account.Balance + Convert.ToInt32(tbsum.Text);
            db_connection.connection.SaveChanges();
            sppos.Visibility = Visibility.Visible;
            sptu.Visibility = Visibility.Hidden;
            NavigationService.Navigate(new PageMain(Issuer));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageLogin());
        }

        private void btnYourInvestors_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageYourInvestor(Issuer));
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageStats(Issuer));
        }
    }
}
