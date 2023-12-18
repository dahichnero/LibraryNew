using Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public Book Bookk { get; set; }
        public List<Genre> Genres { get; set; }
        public Genre Genree { get; set; }
        public Genre GenreeMy { get; set; }
        public Provisioner Provisionere { get; set; }
        public List<Provisioner> Provisioners { get; set; }
        BookMain bookMain = new BookMain(true, new Book());
        private int errorCount = 0;
        public AddBookWindow(Book book)
        {
            InitializeComponent();
            Bookk = book;
            Genres = Session.Instance.Context.Genres.ToList();
            Provisioners = Session.Instance.Context.Provisioners.ToList();
            if (Bookk.Isbn == null)
            {
                choose.Content = "Добавление книги";
            }
            else
            {
                Provisionere = Bookk.ProvisionerNavigation;
                choose.Content = "Изменение книги";
                isbnText.IsEnabled=false;
                izdText.IsEnabled = false;
                Genree = Bookk.GenreiNavigation;
            }
            DataContext = this;
        }

        private void Backto(object sender, RoutedEventArgs e)
        {
            if (choose.Content == "Изменение книги")
            {
                Session.Instance.Context.Entry(Bookk).Reload();
            }
            BackToMain();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ren(object sender, RoutedEventArgs e)
        {
            if (choose.Content == "Изменение книги")
            {
                Session.Instance.Context.Entry(Bookk).Reload();
            }
            BackToMain();
        }
        private void addorupdate(object sender, RoutedEventArgs e)
        {
            
            if (choose.Content == "Добавление книги")
            {

                Session.Instance.Context.Books.Add(Bookk);

            }
            try
            {
                Session.Instance.Context.SaveChanges();
                MessageBox.Show("Успешно!");
                BookMain bookMainTrue = new BookMain(true, Bookk);
                bookMainTrue.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                if (choose.Content == "Добавление книги")
                {
                    Session.Instance.Context.Remove(Bookk);
                }
            }
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

        private void errors(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                errorCount++;
                var errorToolTip = new ToolTip();
                errorToolTip.Content = e.Error.ErrorContent;
                (sender as ComboBox).ToolTip = errorToolTip;
            }
            if (e.Action == ValidationErrorEventAction.Removed)
            {
                errorCount--;
            }
            add.IsEnabled = errorCount == 0;
        }
    }
}
