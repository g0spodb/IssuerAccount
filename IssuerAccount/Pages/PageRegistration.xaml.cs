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
            ComboBoxItem selectedItem = cb.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                string selectedContent = selectedItem.Content.ToString();
                if (selectedContent == "Инвестор")
                {
                    var ac = new Account();
                    ac.Balance = 0;
                    ac.OpeningDate = DateTime.Now;
                    db_connection.connection.Account.Add(ac);
                    var a = new Investor
                    {
                        FullName = tbFullName.Text,
                        Phone = tbPhone.Text,
                        Adress = tbAdress.Text,
                        Login = tbLogin.Text,
                        Password = pbPassword.Password,
                        Id_Account = ac.Id
                    };
                    db_connection.connection.Investor.Add(a);
                    db_connection.connection.SaveChanges();
                    MessageBox.Show("Вы успешно зарегестрированы, инвестор " + a.FullName);
                    NavigationService.GoBack();
                }
                else if (selectedContent == "Эмитент")
                {
                    var a = new Issuer
                    {
                        FullName = tbFullName.Text,
                        Phone = tbPhone.Text,
                        Adress = tbAdress.Text,
                        Login = tbLogin.Text,
                        Password = pbPassword.Password
                    };
                    db_connection.connection.Issuer.Add(a);
                    db_connection.connection.SaveChanges();
                    MessageBox.Show("Вы успешно зарегестрированы, эмитент " + a.FullName);
                    NavigationService.GoBack();
                }
            }
        }
        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
