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
    /// Логика взаимодействия для PageSecurityList.xaml
    /// </summary>
    public partial class PageSecurityList : Page
    {
        public Issuer Issuer { get; set; }
        public static ObservableCollection<Security> securities { get; set; }
        public PageSecurityList(Issuer issuer)
        {
            InitializeComponent();
            Issuer = issuer;
            securities = new ObservableCollection<Security>(db_connection.connection.Security.Where(c => c.RegistrationStatus == true && c.Id_Issuer == Issuer.Id).ToList());
            this.DataContext = this;
        }

        private void LViewSecurities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSaleSecurity_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageSaleSecurity(Issuer));
        }
    }
}
