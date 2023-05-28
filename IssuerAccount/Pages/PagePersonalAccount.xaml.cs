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
    }
}
