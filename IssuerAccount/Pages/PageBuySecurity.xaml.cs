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
    /// Логика взаимодействия для PageBuySecurity.xaml
    /// </summary>
    public partial class PageBuySecurity : Page
    {
        public Investor Investor { get; set; }
        public static ObservableCollection<Security> securities { get; set; }
        public PageBuySecurity(Investor investor)
        {
            InitializeComponent();
            Investor = investor;
            securities = new ObservableCollection<Security>(db_connection.connection.Security.Where(c => c.RegistrationStatus == true && c.SaleStatus == null).ToList());
            this.DataContext = this;
        }

        private void btnBuySecurity_Click(object sender, RoutedEventArgs e)
        {

            var selectedItem = (Security)lv.SelectedItem;
            if (selectedItem != null)
            {
                var Account = db_connection.connection.Account.FirstOrDefault(q => q.Id == Investor.Id_Account);
                if (Account.Balance >= selectedItem.Price)
                {
                    Account.Balance = Account.Balance - selectedItem.Price;
                    selectedItem.SaleStatus = true;
                    var d = new Deal
                    {
                        Id_Security = selectedItem.Id,
                        Id_Investor = Investor.Id,
                        Quantity = selectedItem.Quantity,
                        Price = selectedItem.Price,
                        Date = DateTime.Now
                    };
                    db_connection.connection.Deal.Add(d);
                    db_connection.connection.SaveChanges();
                    MessageBox.Show("Вы успешно приобрели ценную бумагу, она будет отображена в вашем портфеле");

                    NavigationService.Navigate(new PageInvestor(Investor));

                    //securities = new ObservableCollection<Security>(db_connection.connection.Security.Where(c => c.RegistrationStatus == true && c.SaleStatus == null).ToList());
                    //lv.ItemsSource = securities;
                    //lv.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("На вашем счету недостаточно средств для покупки");
                }
            }
            else
            {
                MessageBox.Show("Выберите ценную бумагу");
            }
        }
    }
}
