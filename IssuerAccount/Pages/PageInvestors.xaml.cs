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
    /// Логика взаимодействия для PageInvestors.xaml
    /// </summary>
    public partial class PageInvestors : Page
    {
        public static ObservableCollection<Investor> investors { get; set; }
        public PageInvestors()
        {
            InitializeComponent();
            investors = new ObservableCollection<Investor>(db_connection.connection.Investor.ToList());
            this.DataContext = this;
        }

        private void btnAccDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Investor)lvInvestors.SelectedItem;
            if (selectedItem != null)
            {
                db_connection.connection.Investor.Remove(selectedItem);
                db_connection.connection.SaveChanges();
                MessageBox.Show("Инвестор " + selectedItem.FullName + " удалён");
                investors = new ObservableCollection<Investor>(db_connection.connection.Investor.ToList());
                lvInvestors.ItemsSource = investors;
                lvInvestors.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите инвестора");
            }
        }
    }
}
