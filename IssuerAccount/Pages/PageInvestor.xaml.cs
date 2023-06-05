﻿using IssuerAccount.Model;
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
    /// Логика взаимодействия для PageInvestor.xaml
    /// </summary>
    public partial class PageInvestor : Page
    {
        public Investor Investor { get; set; }
        public static ObservableCollection<Notification> notifications { get; set; }
        public static int countt { get; set; }
        public PageInvestor(Investor investor)
        {
            InitializeComponent();
            Investor = investor;
            statusImage.Source = new BitmapImage(new Uri("/IssuerAccount;component/Resourses/galka.png", UriKind.Relative));
            statusText.Text = "Ваш счет открыт, баланс:";
            var notifications = db_connection.connection.Notification.Where(i => i.Id_Investor == Investor.Id).ToList();
            countt = notifications.Count;
            this.DataContext = this;
        }

        private void btnSecurities_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageBuySecurity(Investor));
        }

        private void btnDeal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            try {
            var Account = db_connection.connection.Account.FirstOrDefault(q => q.Id == Investor.Id_Account);
            Account.Balance = Account.Balance + Convert.ToInt32(tbsum.Text);
            db_connection.connection.SaveChanges();
            sppos.Visibility = Visibility.Visible;
            sptu.Visibility = Visibility.Hidden;
            NavigationService.Navigate(new PageInvestor(Investor));
            }
            catch
            {
                MessageBox.Show("Введите корректную сумму");
            }
        }

        private void btnTopUpBalance_Click(object sender, RoutedEventArgs e)
        {
            sppos.Visibility = Visibility.Hidden;
            sptu.Visibility = Visibility.Visible;
        }

        private void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PageInvestorAccount(Investor));
        }

        private void btnYourDeal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageYourDeal(Investor));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageLogin());
        }

        private void btnNotif_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageNotifInvestor(Investor));
        }
    }
}
