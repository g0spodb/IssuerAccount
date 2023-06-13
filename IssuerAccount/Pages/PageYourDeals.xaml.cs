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
    /// Логика взаимодействия для PageYourDeals.xaml
    /// </summary>
    public partial class PageYourDeals : Page
    {
        public Issuer Issuer { get; set; }
        public static ObservableCollection<Deal> deals { get; set; }
        public PageYourDeals(Issuer issuer)
        {
            InitializeComponent();
            Issuer = issuer;
            deals = new ObservableCollection<Deal>(db_connection.connection.Deal.Where(c => c.Id_Issuer == Issuer.Id).ToList());
            this.DataContext = this;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMain(Issuer));
        }

        private void btnPayout_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Deal)lv.SelectedItem;
            if (selectedItem != null)
            {
                if(selectedItem.IsPaid == false || selectedItem.IsPaid == null)
                {
                    var Acc = db_connection.connection.Account.FirstOrDefault(z => z.Id == Issuer.Id_Account);
                    if (Acc.Balance >= selectedItem.Price * 1.1)
                    {
                        Acc.Balance = Acc.Balance - Convert.ToInt32(selectedItem.Price * 1.1);
                        selectedItem.IsPaid = true;
                        MessageBox.Show("Средства успешно выплачены");
                        db_connection.connection.SaveChanges();
                        deals = new ObservableCollection<Deal>(db_connection.connection.Deal.Where(c => c.Id_Issuer == Issuer.Id).ToList());
                        lv.ItemsSource = deals;
                        lv.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("У вас не хватает средств для выплаты");
                    }
                }
                else
                {
                    MessageBox.Show("Данная сделка уже выплачена ");
                }
                selectedItem.IsPaid = true;
            }
            else
            {
                MessageBox.Show("Выберите сделку");
            }
        }
    }
}
