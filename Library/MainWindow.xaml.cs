using Library.Models;
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

namespace Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            var wnd = (isKioskCheckBox.IsChecked, pass.Password, log.Text) switch //авторизация
            {
                (false, "11037", "librarian") => new BookMain(true, new Book()),
                (true, _,_)=>new BookMain(false, new Book()),
                _ => null
            };
            if (wnd is null)
            {
                MessageBox.Show("Не верные данные", "Вход не выполнен", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                wnd.Show();
                Close();
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
