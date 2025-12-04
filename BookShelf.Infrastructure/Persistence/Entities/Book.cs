using System;
using System.Collections.Generic;

namespace BookShelf.Infrastructure.Persistence.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Isbn { get; set; }

    public int? PublishedYear { get; set; }

    public int? GenreId { get; set; }

    public int StatusId { get; set; }

    public double? Rating { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual BookStatus Status { get; set; } = null!;
}
