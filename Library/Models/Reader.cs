using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Library.Models;

public partial class Reader:IDataErrorInfo
{
    Regex regex = new Regex(@"[A-Za-z]+[A-Za-z0-9]*@[A-Za-z]+\.[A-Za-z]+");
    Regex regex1 = new Regex(@"\+7\d{10}");
    public string this[string columnName] 
    {
        get
        {
            if (columnName == "ReaderName" && string.IsNullOrWhiteSpace(ReaderName))
            {
                return "Имя читателя не может быть пустым!";
            }
            if (columnName == "ReaderName" && ReaderName.Length<=0 && ReaderName.Length>50)
            {
                return "Имя читателя не может быть больше 50!";
            }

            if (columnName == "LastName" && string.IsNullOrWhiteSpace(LastName))
            {
                return "Фамилия читателя не может быть пустой!";
            }
            if (columnName == "LastName" && LastName.Length <= 0 && LastName.Length > 50)
            {
                return "Фамилия читателя не может быть больше 50!";
            }

            if (columnName == "SurName" && string.IsNullOrWhiteSpace(SurName))
            {
                return "Отчество читателя не может быть пустым!";
            }
            if (columnName == "SurName" && SurName.Length <= 0 && SurName.Length > 50)
            {
                return "Отчество читателя не может быть больше 50!";
            }
            if (columnName == "ReaderEmail" && string.IsNullOrWhiteSpace(ReaderEmail))
            {
                return "Электронная почта читателя не может быть пустой!";
            }
            if (columnName == "ReaderEmail" && regex.IsMatch(ReaderEmail) == false)
            {
                return "Неправильный адрес электронной почты!";
            }
            if (columnName == "Phone" && string.IsNullOrWhiteSpace(Phone))
            {
                return "Номер телефона не может быть пустым!";
            }
            if (columnName == "Phone" && regex1.IsMatch(Phone) == false)
            {
                return "Неправильный номер телефона!";
            }
            return null!;
        }
    }

    public int ReaderId { get; set; }

    public string ReaderName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string SurName { get; set; } = null!;

    public string ReaderEmail { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Extradition> Extraditions { get; } = new List<Extradition>();

    public string Error => null!;
}
