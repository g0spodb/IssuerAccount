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
