using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Provisioner
{
    public int ProvisionerId { get; set; }

    public string ProvisionerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
