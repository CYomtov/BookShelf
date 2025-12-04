using System;
using System.Collections.Generic;

namespace BookShelf.Infrastructure.Persistence.Entities;

public partial class BookStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
