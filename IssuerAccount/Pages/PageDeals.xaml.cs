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
    /// Логика взаимодействия для PageDeals.xaml
    /// </summary>
    public partial class PageDeals : Page
    {
        public Registrar Registrar { get; set; }
        public static ObservableCollection<Deal> deals { get; set; }
        public PageDeals(Registrar registrar)
        {
            InitializeComponent();
            Registrar = registrar;
            deals = new ObservableCollection<Deal>(db_connection.connection.Deal.ToList());
            this.DataContext = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageRegistrar(Registrar));
        }
    }
}
