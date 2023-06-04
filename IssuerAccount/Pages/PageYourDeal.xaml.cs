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
    /// Логика взаимодействия для PageYourDeal.xaml
    /// </summary>
    public partial class PageYourDeal : Page
    {
        public static ObservableCollection<Deal> deals { get; set; }
        public Investor Investor { get; set; }
        public PageYourDeal(Investor investor)
        {
            InitializeComponent();
            Investor = investor;
            deals = new ObservableCollection<Deal>(db_connection.connection.Deal.Where(c => c.Id_Investor == Investor.Id).ToList());
            this.DataContext = this;
        }
    }
}
