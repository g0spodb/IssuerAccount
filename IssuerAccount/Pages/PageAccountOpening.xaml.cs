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
    /// Логика взаимодействия для PageAccountOpening.xaml
    /// </summary>
    public partial class PageAccountOpening : Page
    {
        public static ObservableCollection<AccountOpeningApplication> accountOpeningApplications { get; set; }
        public static ObservableCollection<Issuer> issuers { get; set; }
        public Registrar Registrar { get; set; }
        public PageAccountOpening(Registrar registrar)
        {
            InitializeComponent();
            Registrar = registrar;
            accountOpeningApplications = new ObservableCollection<AccountOpeningApplication>(db_connection.connection.AccountOpeningApplication.Where(c => c.RegistrationStatus == false).ToList());
            this.DataContext = this;
        }

        private void btnAccOpen_Click(object sender, RoutedEventArgs e)
        {
            
            var selectedItem = (AccountOpeningApplication)lv.SelectedItem;
            if (selectedItem != null)
            { 
            selectedItem.RegistrationStatus = true;
            selectedItem.DateApprovalApplication = DateTime.Now;
            selectedItem.Id_Registrar = Registrar.Id;
            db_connection.connection.SaveChanges();
            var a = new Account();
            a.Balance = 0;
            a.OpeningDate = DateTime.Now;
            db_connection.connection.Account.Add(a);
            issuers = new ObservableCollection<Issuer>(db_connection.connection.Issuer.ToList());
            var issuer = db_connection.connection.Issuer.FirstOrDefault(q => q.Id == selectedItem.Id_Issuer);
            if (issuer != null)
            {
                issuer.Id_Account = a.Id;
            }
            else { }
            db_connection.connection.SaveChanges();
            MessageBox.Show("Вы зарегестрировали эмитента " + issuer.FullName);
                accountOpeningApplications = new ObservableCollection<AccountOpeningApplication>(db_connection.connection.AccountOpeningApplication.Where(c => c.RegistrationStatus == false).ToList());
                lv.ItemsSource = accountOpeningApplications;
                lv.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите заявку");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRegistrar(Registrar));
        }
    }
}
