﻿using IssuerAccount.Model;
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
    /// Логика взаимодействия для PageSecurityList.xaml
    /// </summary>
    public partial class PageSecurityList : Page
    {
        public Issuer Issuer { get; set; }
        public PageSecurityList(Issuer issuer)
        {
            InitializeComponent();
            Issuer = issuer;
            this.DataContext = this;
        }

        private void LViewSecurities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
