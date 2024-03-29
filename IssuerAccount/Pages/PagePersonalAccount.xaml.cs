﻿using IssuerAccount.Model;
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
    /// Логика взаимодействия для PagePersonalAccount.xaml
    /// </summary>
    public partial class PagePersonalAccount : Page
    {
        public Issuer Issuer { get; set; }
        public PagePersonalAccount(Issuer issuer)
        {
            InitializeComponent();
            Issuer = issuer;
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
                Issuer.Photo = File.ReadAllBytes(openFile.FileName);
                IssuerPhoto.Source = new BitmapImage(new Uri(openFile.FileName));
            }
            db_connection.connection.SaveChanges();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            spedit.Visibility = Visibility.Visible;
        }

        private void btnEditConf_Click(object sender, RoutedEventArgs e)
        {
            Issuer.FullName = tbFullName.Text;
            Issuer.Phone = tbPhone.Text;
            Issuer.Adress = tbAdress.Text;
            Issuer.Login = tbLogin.Text;
            Issuer.NameOrganization = tbNameOrg.Text;
            Issuer.Password = pbPassword.Text;
            db_connection.connection.SaveChanges();
            MessageBox.Show("Ваши данные успешно изменены");
            NavigationService.Navigate(new PagePersonalAccount(Issuer));
            spedit.Visibility = Visibility.Hidden;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            spedit.Visibility = Visibility.Hidden;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMain(Issuer));
        }
    }
}
