using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
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
    /// Логика взаимодействия для BookMain.xaml
    /// </summary>
    public partial class BookMain : Window
    {
        public ObservableCollection<Book> Books { get; private set; }
        public ObservableCollection<Genre> Genres { get; private set; }
        public ObservableCollection<Extradition> ForCheck { get; set; }
        public Book book1 { get; set; }
        public bool IsLib { get; set; }
        public BookMain(bool islib, Book book)
        {
            IsLib = islib;
            Books = new ObservableCollection<Book>(Session.Instance.Context.Books);
            if (book.Isbn != null)
            {
                book1 = book;
                Books.Add(book1);
            }
            InitializeComponent();
            Genres = new ObservableCollection<Genre>(Session.Instance.Context.Genres);//вход как гость
            if (!IsLib)
            {
                addingbook.Visibility = Visibility.Hidden;
                addingreader.Visibility = Visibility.Hidden;
                vid.Visibility = Visibility.Hidden;
                readersGo.Visibility = Visibility.Hidden;
            }
        }

        private void CloseAway(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void VidB(object sender, RoutedEventArgs e)
        {
            VidBooks vidBooks = new VidBooks();
            vidBooks.Show();
            this.Close();
        }

        private void toAddBook(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow(new Book());
            addBookWindow.Show();
            this.Close();
        }

        private void toAddReader(object sender, RoutedEventArgs e)
        {
            AddReaderWindow addReaderWindow = new AddReaderWindow(new Reader());
            addReaderWindow.Show();
            this.Close();
        }

        private void toAddVid(object sender, RoutedEventArgs e)
        {
            var booking = (sender as Button)?.DataContext as Book;
            if (booking == null) return;
            if (booking.Count>0)
            {
                AddVidWindow addVidWindow = new AddVidWindow(booking, new Extradition());
                addVidWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Количество книг равно нулю. Подождите возвращения книг!");
            }
        }

        private IQueryable<Book> applySearch(IQueryable<Book> query) =>
        query.Where(q => q.BookName.Contains(searchTextBox.Text) ||
        q.Author.Contains(searchTextBox.Text) || q.GenreiNavigation.GenreName.Contains(searchTextBox.Text));

        

        private void applyFilters()
        {

            Books.Clear();
            IQueryable<Book> query = Session.Instance.Context.Books.AsQueryable();
            query = applySearch(query);

            foreach (Book service in query)
            {
                Books.Add(service);
            }
        }

        private void search(object sender, TextChangedEventArgs e)
        {
            applyFilters();
        }


        private void remove(object sender, RoutedEventArgs e)
        {
            var booking = (sender as Button)?.DataContext as Book;
            if (booking == null) return;
            bool hasExtraditions = Session.Instance.Context.Extraditions.Any(s => s.Book == booking.Isbn);
            if (hasExtraditions)
            {
                MessageBox.Show("Невозможно удалить книгу, по которой есть выдача", "Удаление невозможно",
            MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var answer = MessageBox.Show("Вы уверены, что хотите удалить запись", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    Session.Instance.Context.Books.Remove(booking);
                    Session.Instance.Context.SaveChanges();
                    Books.Remove(booking);
                    MessageBox.Show("Книга удалена.", "Удаление успешно",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void change(object sender, RoutedEventArgs e)
        {
            var booking=(sender as Button)?.DataContext as Book;
            if (booking == null) return;
            AddBookWindow addBookWindow = new AddBookWindow(booking);
            addBookWindow.Show();
            this.Close();
        }

        private void GoToReaders(object sender, RoutedEventArgs e)
        {
            Readers readers = new Readers();
            readers.Show();
            this.Close();
        }

        private void ShowImage(object sender, RoutedEventArgs e)
        {
            var booking=( sender as Button)?.DataContext as Book;
            if (booking == null) return;
            if (booking.ImagePath != null)
            {
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", booking.ImagePath);
            }
            else
            {
                MessageBox.Show("К сожалению, изображения к данной книге нет");
            }
        }
    }
}
