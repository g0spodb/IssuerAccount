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
    /// Логика взаимодействия для PageRegistrar.xaml
    /// </summary>
    public partial class PageRegistrar : Page
    {
        public Registrar Registrar { get; set; }
        public PageRegistrar(Registrar registrar)
        {
            InitializeComponent();
            Registrar = registrar;
            this.DataContext = this;
        }

        private void btnAccountOpening_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAccountOpening(Registrar));
        }

        private void btnIssuers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageIssuers());
        }

        private void btnInvestors_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageInvestors());
        }

        private void btnSecurities_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PagePendingSecurities(Registrar));
        }
    }
}
