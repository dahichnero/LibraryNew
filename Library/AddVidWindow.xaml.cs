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
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для AddVidWindow.xaml
    /// </summary>
    public partial class AddVidWindow : Window
    {
        public Book Bookk { get; set; }
        public Reader Read { get; set; }
        public List<Reader> Readers { get; set; }
        BookMain bookMain = new BookMain(true, new Book());
        public Extradition Extradition { get; set; }
        public AddVidWindow(Book book, Extradition extradition)
        {
            InitializeComponent();
            Bookk = book;
            Extradition = extradition;
            Readers = Session.Instance.Context.Readers.ToList();
            if (Extradition.ExtraditionId == 0)
            {
                Extradition.BookNavigation = Bookk;
                titlee.Content = "Оформление выдачи";
                booking.Text = $"{Bookk.BookName} {Bookk.Author} {Bookk.YearIzd}";
                vidDate.DisplayDateStart = DateTime.Today;
                vidDate.SelectedDate = DateTime.Today;
            }
            else
            {
                titlee.Content = "Изменение выдачи";
                Bookk = Extradition.BookNavigation;
                booking.Text = $"{Extradition.BookNavigation.BookName} {Extradition.BookNavigation.Author} {Extradition.BookNavigation.YearIzd}";
                Read = Extradition.ReaderNavigation;
                backDate.Text=Extradition.DateBack.ToString();
                vidDate.Text=Extradition.DateExtra.ToString();
            }
            DataContext = this;
        }

        private void Backto(object sender, RoutedEventArgs e)
        {
            if (Extradition.ExtraditionId != 0)
            {
                Session.Instance.Context.Entry(Extradition).Reload();
            }
            BackToMain();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        bool HasDate()
        {
            if (backDate.Text!="" && vidDate.Text != "")
            {
                return true;
            }
            return false;
        }
        bool IsValid(DateTime date, DateTime date1)
        {
            bool res = date < date1;
            int r = date1.Subtract(date).Days;
            if (Bookk != null && res == true && r == 14)
            {
                return true;
            }
            return false;
        }
        private void adding(object sender, RoutedEventArgs e)
        {
            if (HasDate()==true)
            {
                DateTime dateTime = vidDate.SelectedDate.Value;
                DateTime dateTime1 = backDate.SelectedDate.Value;
                if (IsValid(dateTime, dateTime1)==true)
                {
                    if (Extradition.ReaderNavigation != null)
                    {
                        Extradition.DateExtra = dateTime;
                        Extradition.DateBack = dateTime1;
                        if (Extradition.ExtraditionId == 0)
                        {
                            Bookk.Count = Bookk.Count - 1;
                            Session.Instance.Context.Extraditions.Add(Extradition);
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
                            if (Extradition.ExtraditionId == 0)
                            {
                                Session.Instance.Context.Remove(Extradition);
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбран читатель...");
                    }
                }
                else
                {
                    MessageBox.Show("Некорректная дата выдачи...");
                }
            }
            else
            {
                MessageBox.Show("Не указана дата...");
            }
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            if (Extradition.ExtraditionId != 0)
            {
                Session.Instance.Context.Entry(Extradition).Reload();
            }
            BackToMain();
        }

        private void readersearch(object sender, TextChangedEventArgs e)
        {
            Readers.Clear();
            var query=Session.Instance.Context.Readers.Where(s=>s.ReaderName.Contains(searches.Text) || s.SurName.Contains(searches.Text) || s.LastName.Contains(searches.Text)).ToList();
            foreach (var reader in  query)
            {
                Readers.Add(reader);
            }
        }
        void BackToMain()
        {
            bookMain.Show();
            this.Close();
        }
    }
}
