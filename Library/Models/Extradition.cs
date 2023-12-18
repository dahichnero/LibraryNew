using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Extradition
{
    public int ExtraditionId { get; set; }

    public string? Book { get; set; }

    public int? Reader { get; set; }

    public DateTime DateExtra { get; set; }

    public DateTime DateBack { get; set; }

    public virtual Book? BookNavigation { get; set; }

    public virtual Reader? ReaderNavigation { get; set; }

    public int IsThatTrue
    {
        get
        {
            int result = DateTime.Compare(DateBack, DateTime.Now);
            if (result < 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
