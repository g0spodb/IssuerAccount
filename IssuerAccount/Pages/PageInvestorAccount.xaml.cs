using IssuerAccount.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageInvestorAccount.xaml
    /// </summary>
    public partial class PageInvestorAccount : Page
    {
        public Investor Investor { get; set; }
        public PageInvestorAccount(Investor investor)
        {
            InitializeComponent();
            Investor = investor;
            this.DataContext = this;
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                Investor.Photo = File.ReadAllBytes(openFile.FileName);
                InvestorPhoto.Source = new BitmapImage(new Uri(openFile.FileName));
            }
            db_connection.connection.SaveChanges();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            spedit.Visibility = Visibility.Visible;
        }

        private void btnEditConf_Click(object sender, RoutedEventArgs e)
        {
            Investor.FullName = tbFullName.Text;
            Investor.Phone = tbPhone.Text;
            Investor.Adress = tbAdress.Text;
            Investor.Login = tbLogin.Text;
            Investor.Password = pbPassword.Text;
            db_connection.connection.SaveChanges();
            MessageBox.Show("Ваши данные успешно изменены");
            spedit.Visibility = Visibility.Hidden;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            spedit.Visibility = Visibility.Hidden;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageInvestor(Investor));
        }
    }
}
