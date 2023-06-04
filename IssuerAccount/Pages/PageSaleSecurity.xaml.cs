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

namespace IssuerAccount.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageSaleSecurity.xaml
    /// </summary>
    public partial class PageSaleSecurity : Page
    {
        public Issuer Issuer { get; set; }
        public PageSaleSecurity(Issuer issuer)
        {
            InitializeComponent();

            Issuer = issuer;
            this.DataContext = this;
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            var Account = db_connection.connection.Account.FirstOrDefault(q => q.Id == Issuer.Id_Account);
            int i = (int)Account.Balance;
            if (i > Convert.ToInt32(tbPrice.Text))
            {
                var a = new Security
                {
                    Name = tbName.Text,
                    Quantity = Convert.ToInt32(tbQuantity.Text),
                    Price = Convert.ToInt32(tbPrice.Text),
                    Id_Issuer = Issuer.Id,
                    Date = DateTime.Now
                };
                Account.Balance = Account.Balance - (Convert.ToInt32(tbPrice.Text));
                db_connection.connection.Security.Add(a);
                db_connection.connection.SaveChanges();
                MessageBox.Show("Ценная бумага успешно выставлена на продажу, ожидайте проверки");
            }
            else
            {
                MessageBox.Show("У вас недостаточно средств");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageSecurityList(Issuer));
        }
    }
}
