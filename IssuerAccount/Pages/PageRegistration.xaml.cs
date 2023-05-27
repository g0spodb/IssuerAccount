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
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            var a = new Issuer();
            a.FullName = tbFullName.Text;
            a.Phone = tbPhone.Text;
            a.Login = tbLogin.Text;
            a.Password = pbPassword.Password;
            db_connection.connection.Issuer.Add(a);
            db_connection.connection.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрированы " + a.FullName);
            NavigationService.GoBack();
        }
    }
}
