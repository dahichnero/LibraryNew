using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Library.Models;

public partial class Book :IDataErrorInfo
{
    Regex regex = new Regex(@"978\d{10}");
    public string this[string columnName]
    {
        get
        {
            if (columnName == "BookName" && string.IsNullOrWhiteSpace(BookName))
            {
                return "Название книги не может быть пустым!";
            }
            if (columnName == "BookName" && BookName.Length > 50)
            {
                return "Название книги не может содержать более 50 знаков!";
            }
            if (columnName == "Author" && string.IsNullOrWhiteSpace(Author))
            {
                return "Поле Автор не может быть пустым!";
            }
            if (columnName == "Author" && Author.Length > 100)
            {
                return "Поле Автор не может содержать более 100 знаков!";
            }
            if (columnName == "YearIzd" && YearIzd>DateTime.Now.Year)
            {
                return "Год не должен превышать нынешний!";
            }
            if (columnName == "YearIzd" && YearIzd <100)
            {
                return "Год не должен быть отрицательным или слишком маленьким!";
            }
            if (columnName == "Count" && Count<=0)
            {
                return "Количество не должно быть меньше или равно нулю!";
            }
            if (columnName == "Price" && Price <= 0)
            {
                return "Цена не должна быть меньше или равно нулю!";
            }
            if (columnName == "Price" && Price>=1000)
            {
                return "Цена не должна быть больше 1000!";
            }
            if (columnName == "GenreiNavigation" && GenreiNavigation==null)
            {
                return "Не выбран жанр!";
            }
            if (columnName == "ProvisionerNavigation" && ProvisionerNavigation == null)
            {
                return "Не выбрано издательство!";
            }
            if (columnName == "Isbn" && string.IsNullOrWhiteSpace(Isbn))
            {
                return "Isbn не может быть пустым!";
            }
            if (columnName == "Isbn" && regex.IsMatch(Isbn)==false)
            {
                return "Неправильный Isbn!";
            }
            if (columnName == "Isbn" && ProvisionerNavigation==null)
            {
                return "Isbn не советуется писать, если издательство не выбрано!";
            }
            if (columnName == "Isbn" && Isbn.Contains(ProvisionerNavigation!.ProvisionerId.ToString())==false)
            {
                return "Isbn не того издательства!";
            }
            return null!;
        }
    }

    public string Isbn { get; set; } = null!;

    public string BookName { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int? Provisioner { get; set; }

    public int? Genrei { get; set; }

    public int YearIzd { get; set; }

    public int? Price { get; set; }

    public int? Count { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<Extradition> Extraditions { get; } = new List<Extradition>();

    public virtual Genre? GenreiNavigation { get; set; }

    public virtual Provisioner? ProvisionerNavigation { get; set; }

    public string Error => null!;
}
