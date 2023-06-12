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
    /// Логика взаимодействия для PagePendingSecurities.xaml
    /// </summary>
    public partial class PagePendingSecurities : Page
    {
        public static ObservableCollection<Security> pendingSecurities { get; set; }
        public Registrar Registrar { get; set; }
        public PagePendingSecurities(Registrar registrar)
        {
            InitializeComponent();
            Registrar = registrar;
            pendingSecurities = new ObservableCollection<Security>(db_connection.connection.Security.Where(c => c.RegistrationStatus == null).ToList());
            this.DataContext = this;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Security)lv.SelectedItem;
            if (selectedItem != null)
            {
                selectedItem.RegistrationStatus = true;
                selectedItem.Id_Registrar = Registrar.Id;
                db_connection.connection.SaveChanges();
                MessageBox.Show("Вы подтвердили продажу данной ценной бумаги");
                pendingSecurities = new ObservableCollection<Security>(db_connection.connection.Security.Where(c => c.RegistrationStatus == null).ToList());
                lv.ItemsSource = pendingSecurities;
                lv.Items.Refresh();
                selectedItem.Quantity = selectedItem.Quantity - 1;
                var d = new Deal
                {
                    Id_Security = selectedItem.Id,
                    Id_Investor = 9,
                    Quantity = 1,
                    Price = selectedItem.Price,
                    Date = DateTime.Now,
                    Id_Issuer = selectedItem.Id_Issuer,
                    IsPaid = false
                };
                var iss = db_connection.connection.Issuer.FirstOrDefault(z => z.Id == selectedItem.Id_Issuer);
                var Acc = db_connection.connection.Account.FirstOrDefault(z => z.Id == iss.Id_Account);
                Acc.Balance = Acc.Balance + (selectedItem.Price * 2);
                db_connection.connection.Deal.Add(d);
                var x = new Deal
                {
                    Id_Security = selectedItem.Id,
                    Id_Investor = 8,
                    Quantity = 1,
                    Price = selectedItem.Price,
                    Date = DateTime.Now,
                    Id_Issuer = selectedItem.Id_Issuer,
                    IsPaid = false
                };
                db_connection.connection.Deal.Add(x);
                db_connection.connection.SaveChanges();
            }
            else
            {
                MessageBox.Show("Выберите ценную бумагу");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRegistrar(Registrar));
        }
    }
}
