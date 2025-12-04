using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Isbn { get; set; }
        public int? PublishedYear { get; set; }

        public string? Genre { get; set; }      // Genre name
        public string Status { get; set; } = null!; // Status name

        public double? Rating { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
