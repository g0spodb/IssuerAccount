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
    /// Логика взаимодействия для PageIssuers.xaml
    /// </summary>
    public partial class PageIssuers : Page
    {
        public Registrar Registrar { get; set; }
        public static ObservableCollection<Issuer> issuers { get; set; }
        public static ObservableCollection<AccountOpeningApplication> accountOpeningApplications { get; set; }
        public PageIssuers(Registrar registrar)
        {
            InitializeComponent();
            issuers = new ObservableCollection<Issuer>(db_connection.connection.Issuer.ToList());
            Registrar = registrar;
            this.DataContext = this;
        }

        private void btnAccDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Issuer)lvIssuers.SelectedItem;
            if (selectedItem != null)
            {
                db_connection.connection.Issuer.Remove(selectedItem);
                var accountOpeningApplication = db_connection.connection.AccountOpeningApplication.FirstOrDefault(q => q.Id_Issuer == selectedItem.Id);
                if (accountOpeningApplication != null)
                {
                    db_connection.connection.AccountOpeningApplication.Remove(accountOpeningApplication);
                }
                else { }
                db_connection.connection.SaveChanges();
                MessageBox.Show("Эмитент " + selectedItem.FullName + " удалён");
                issuers = new ObservableCollection<Issuer>(db_connection.connection.Issuer.ToList());
                lvIssuers.ItemsSource = issuers;
                lvIssuers.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите эмитента");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRegistrar(Registrar));
        }
    }
}
