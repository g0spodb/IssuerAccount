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
using System.Windows.Shapes;

namespace IssuerAccount.Windows
{
    /// <summary>
    /// Логика взаимодействия для ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        public ConfirmationWindow()
        {
            InitializeComponent();
        }
        public bool isConfirmed = false; // Переменная для хранения результата выбора

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            isConfirmed = true; // Установка значения "Да"
            Close(); // Закрытие окна
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            isConfirmed = false; // Установка значения "Нет"
            Close(); // Закрытие окна
        }
    }
}
