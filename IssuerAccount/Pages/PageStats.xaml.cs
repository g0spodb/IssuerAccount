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
    /// Логика взаимодействия для PageStats.xaml
    /// </summary>
    public partial class PageStats : Page
    {
        public Issuer Issuer { get; set; }
        public PageStats(Issuer issuer)
        {
            InitializeComponent();
            Issuer = issuer;
            FillStatistics();   
            this.DataContext = this;
        }
        private void FillStatistics()
        {
            using (var context = new IssuerAccountEntities())
            {
                // Получение информации об эмитенте
                var issuer = context.Issuer.FirstOrDefault(i => i.Id == Issuer.Id);
                if (issuer != null)
                {
                    // Заполнение значений статистики
                    totalDealsTextBlock.Text = context.Deal.Count(d => d.Id_Issuer == Issuer.Id).ToString();
                    averageDealPriceTextBlock.Text = context.Deal.Where(d => d.Id_Issuer == Issuer.Id).Max(d => d.Price).ToString();
                    maxSoldSecuritiesTextBlock.Text = context.Deal.Where(d => d.Id_Issuer == Issuer.Id).Max(d => d.Quantity).ToString();
                    totalSoldSecuritiesTextBlock.Text = context.Deal.Where(d => d.Id_Issuer == Issuer.Id).Sum(d => d.Quantity).ToString();
                    decimal totalRevenue = (decimal)context.Deal.Where(d => d.Id_Issuer == Issuer.Id).Sum(d => d.Quantity * d.Price);
                    totalRevenueTextBlock.Text = totalRevenue.ToString();
                    int paidSecuritiesCount = context.Deal.Count(d => d.Id_Issuer == Issuer.Id && d.IsPaid == true);
                    int unpaidSecuritiesCount = context.Deal.Count(d => d.Id_Issuer == Issuer.Id && (d.IsPaid == false || d.IsPaid == null));

                    paidSecuritiesTextBlock.Text = paidSecuritiesCount.ToString();
                    unpaidSecuritiesTextBlock.Text = unpaidSecuritiesCount.ToString();
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageMain(Issuer));
        }
    }
}
