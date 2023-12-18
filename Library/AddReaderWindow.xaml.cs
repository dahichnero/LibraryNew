using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для AddReaderWindow.xaml
    /// </summary>
    public partial class AddReaderWindow : Window
    {
        public Reader Readerr { get; set; }
        BookMain bookMain = new BookMain(true, new Book());
        private int errorCount=0;

        public AddReaderWindow(Reader reader)
        {
            Readerr = reader;
            InitializeComponent();
            DataContext = this;
        }

        private void backTo(object sender, RoutedEventArgs e)
        {
            if (Readerr.ReaderId != 0)
            {
                Session.Instance.Context.Entry(Readerr).Reload();
            }
            BackToMain();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void addup(object sender, RoutedEventArgs e)
        {
            if (Readerr.ReaderId == 0)
            {
                Session.Instance.Context.Readers.Add(Readerr);
            }
            try
            {
                Session.Instance.Context.SaveChanges();
                MessageBox.Show("Успешно!");
                BackToMain();
            }
            catch
            {
                MessageBox.Show("Ошибка");
                Session.Instance.Context.Readers.Remove(Readerr);
            }
        }

        private void rem(object sender, RoutedEventArgs e)
        {
            if (Readerr.ReaderId != 0)
            {
                Session.Instance.Context.Entry(Readerr).Reload();
            }
            BackToMain();
        }
        void BackToMain()
        {
            bookMain.Show();
            this.Close();
        }

        private void error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                errorCount++;
                var errorToolTip = new ToolTip();
                errorToolTip.Content = e.Error.ErrorContent;
                (sender as TextBox).ToolTip = errorToolTip;
            }
            if (e.Action == ValidationErrorEventAction.Removed)
            {
                errorCount--;
            }
            add.IsEnabled = errorCount == 0;
        }
    }
}
