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
    /// Логика взаимодействия для PageNotifInvestor.xaml
    /// </summary>
    public partial class PageNotifInvestor : Page
    {
        public Investor Investor { get; set; }
        public static ObservableCollection<Notification> notifications { get; set; }
        public PageNotifInvestor(Investor investor)
        {
            InitializeComponent();
            Investor = investor;
            this.DataContext = this;
            var notifications = db_connection.connection.Notification.Where(i => i.Id_Investor == Investor.Id).ToList();
            lv.ItemsSource = notifications;
            lv.Items.Refresh();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageInvestor(Investor));
        }

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (Notification)lv.SelectedItem;
            tbText.Text = selectedItem.Text;
        }
    }
}
