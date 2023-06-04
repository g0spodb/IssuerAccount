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
            btnAccept.Visibility = Visibility.Visible;
            spQ.Visibility = Visibility.Visible;
            btnBuySecurity.Visibility = Visibility.Hidden;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageInvestor(Investor));
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Security)lv.SelectedItem;
            string textBoxText = tbQuantity.Text;
            try { 
            int textBoxValue = int.Parse(textBoxText);
            if (textBoxValue < selectedItem.Quantity)
            {
                var Account = db_connection.connection.Account.FirstOrDefault(q => q.Id == Investor.Id_Account);
                if (Account.Balance >= selectedItem.Price * textBoxValue)
                {
                    Account.Balance = Account.Balance - (selectedItem.Price * textBoxValue);
                    selectedItem.Quantity = selectedItem.Quantity - textBoxValue;
                    var d = new Deal
                    {
                        Id_Security = selectedItem.Id,
                        Id_Investor = Investor.Id,
                        Quantity = textBoxValue,
                        Price = selectedItem.Price * textBoxValue,
                        Date = DateTime.Now
                    };
                    db_connection.connection.Deal.Add(d);
                    db_connection.connection.SaveChanges();
                    var Acc = db_connection.connection.Account.FirstOrDefault(q => q.Id == selectedItem.Id_Issuer);
                    Acc.Balance = Acc.Balance + (selectedItem.Price * textBoxValue);
                    MessageBox.Show("Вы успешно приобрели ценную бумагу, она будет отображена в вашем портфеле");
                    NavigationService.Navigate(new PageInvestor(Investor));
                }
                else
                {
                    MessageBox.Show("На вашем счету недостаточно средств для покупки");
                }
            }
            else if (textBoxValue == selectedItem.Quantity)
            {
                var Account = db_connection.connection.Account.FirstOrDefault(q => q.Id == Investor.Id_Account);
                if (Account.Balance >= selectedItem.Price * textBoxValue)
                {
                    Account.Balance = Account.Balance - (selectedItem.Price * textBoxValue);
                    selectedItem.Quantity = selectedItem.Quantity - textBoxValue;
                    selectedItem.SaleStatus = true;
                    var d = new Deal
                    {
                        Id_Security = selectedItem.Id,
                        Id_Investor = Investor.Id,
                        Quantity = textBoxValue,
                        Price = selectedItem.Price * textBoxValue,
                        Date = DateTime.Now
                    };
                    db_connection.connection.Deal.Add(d);
                    db_connection.connection.SaveChanges();
                    MessageBox.Show("Вы успешно приобрели ценную бумагу, она будет отображена в вашем портфеле");
                    NavigationService.Navigate(new PageInvestor(Investor));
                }
                else
                {
                    MessageBox.Show("На вашем счету недостаточно средств для покупки");
                }
            }
            else
            {
                MessageBox.Show("Введенное данное больше количества ценной бумаги на продаже");
            }
            }
            catch
            {
                MessageBox.Show("Неверный формат ввода");
            }
        }
    }
}
