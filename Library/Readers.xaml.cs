using Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Reflection.Metadata.BlobBuilder;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для Readers.xaml
    /// </summary>
    public partial class Readers : Window
    {
        public ObservableCollection<Reader> Readers_ { get; set; }
        public Readers()
        {
            Readers_ = new ObservableCollection<Reader>(Session.Instance.Context.Readers);
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            BookMain bookMain = new BookMain(true, new Book());
            bookMain.Show();
            this.Close();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void change(object sender, RoutedEventArgs e)
        {
            var read = (sender as Button)?.DataContext as Reader;
            if (read == null) return;
            AddReaderWindow addVidWindow = new AddReaderWindow(read);
            addVidWindow.Show();
            this.Close();
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            var reading = (sender as Button)?.DataContext as Reader;
            if (reading == null) return;
            bool hasExtraditions = Session.Instance.Context.Extraditions.Any(s => s.Reader == reading.ReaderId);
            if (hasExtraditions)
            {
                MessageBox.Show("Невозможно удалить читателя, которому выданы книги", "Удаление невозможно",
            MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var answer = MessageBox.Show("Вы уверены, что хотите удалить читателя", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    Session.Instance.Context.Readers.Remove(reading);
                    Session.Instance.Context.SaveChanges();
                    Readers_.Remove(reading);
                    MessageBox.Show("Читатель удален.", "Удаление успешно",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private IQueryable<Reader> applySearch(IQueryable<Reader> query) =>
        query.Where(q => q.ReaderName.Contains(searchTextBox.Text) ||
        q.LastName.Contains(searchTextBox.Text) || q.SurName.Contains(searchTextBox.Text));

        private void search(object sender, TextChangedEventArgs e)
        {
            Readers_.Clear();
            IQueryable<Reader> query = Session.Instance.Context.Readers.AsQueryable();
            query = applySearch(query);
            foreach (Reader q in query)
            {
                Readers_.Add(q);
            }
        }
    }
}
