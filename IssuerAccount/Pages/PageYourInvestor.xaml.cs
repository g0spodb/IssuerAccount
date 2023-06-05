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
    /// Логика взаимодействия для PageYourInvestor.xaml
    /// </summary>
    public partial class PageYourInvestor : Page
    {
        public Issuer Issuer { get; set; }
        public static ObservableCollection<Investor> Investors { get; set; }
        public static ObservableCollection<Security> securities { get; set; }
        public static ObservableCollection<Deal> deals { get; set; }
        public PageYourInvestor(Issuer issuer)
        {
            InitializeComponent();
            Issuer = issuer;
            var securities = db_connection.connection.Security.Where(c => c.Id_Issuer == Issuer.Id).Select(s => s.Id).ToList();
            var deals = new ObservableCollection<Deal>(db_connection.connection.Deal.Where(d => securities.Contains((int)d.Id_Security))).ToList();
            var investorIds = deals.Select(d => d.Id_Investor).Distinct().ToList();
            var investors = db_connection.connection.Investor.Where(i => investorIds.Contains(i.Id)).ToList();
            lv.ItemsSource = investors;
            this.DataContext = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMain(Issuer));
        }

        private void btnNotif_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Investor)lv.SelectedItem;
            sp.Visibility = Visibility.Visible;
            tbFN.Text = selectedItem.FullName;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            btnNotif.Visibility = Visibility.Hidden;
            var selectedItem = (Investor)lv.SelectedItem;
            var n = new Notification
            {
                Id_Investor = selectedItem.Id,
                Id_Issuer = Issuer.Id,
                Text = tbText.Text
            };
            db_connection.connection.Notification.Add(n);
            db_connection.connection.SaveChanges();
            MessageBox.Show("Вы успешно отправили сообщение");
            tbFN.Text = null;
            sp.Visibility = Visibility.Hidden;

        }
    }
}
    