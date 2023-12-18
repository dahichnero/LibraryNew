using Library.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для VidBooks.xaml
    /// </summary>
    public partial class VidBooks : Window
    {
        public ObservableCollection<Extradition> Readers { get; private set; }
        public VidBooks()
        {
            Readers = new ObservableCollection<Extradition>(Session.Instance.Context.Extraditions.Include(s=>s.ReaderNavigation));
            InitializeComponent();
        }

        private void BackMain(object sender, RoutedEventArgs e)
        {
            BookMain bookMain = new BookMain(true, new Book());
            bookMain.Show();
            this.Close();
        }

        private void ToCLose(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private IQueryable<Extradition> applySearch(IQueryable<Extradition> query) =>
        query.Where(q => q.BookNavigation.BookName.Contains(searchTextBox.Text) ||
        q.BookNavigation.Author.Contains(searchTextBox.Text) || q.ReaderNavigation.ReaderName.Contains(searchTextBox.Text) || q.ReaderNavigation.LastName.Contains(searchTextBox.Text));
        
        private void search(object sender, TextChangedEventArgs e)
        {
            Readers.Clear();
            IQueryable<Extradition> query = Session.Instance.Context.Extraditions.AsQueryable();
            query = applySearch(query);
            foreach (Extradition q in query)
            {
                Readers.Add(q);
            }
        }

        private void prinyatie(object sender, RoutedEventArgs e)
        {
            var extradition = (sender as Button)?.DataContext as Extradition;
            if (extradition == null) return;
            var answer = MessageBox.Show("Вы уверены, что хотите удалить запись", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    extradition.BookNavigation.Count += 1;
                    Session.Instance.Context.Extraditions.Remove(extradition);
                    Session.Instance.Context.SaveChanges();
                    Readers.Remove(extradition);
                    MessageBox.Show("Возврат оформлен", "Удаление успешно",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void changeVid(object sender, RoutedEventArgs e)
        {
            var reading = (sender as Button)?.DataContext as Extradition;
            if (reading == null) return;
            AddVidWindow addVidWindow = new AddVidWindow(new Book(), reading);
            addVidWindow.Show();
            this.Close();
        }
    }
}
