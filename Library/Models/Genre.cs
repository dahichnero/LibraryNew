using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
