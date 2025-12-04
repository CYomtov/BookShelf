using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShelf.Application.DTOs
{
    public class CreateBookDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Author { get; set; } = null!;

        [StringLength(20)]
        public string? Isbn { get; set; }

        [Range(0, 3000, ErrorMessage = "Published year must be between 0 and 3000.")]
        public int? PublishedYear { get; set; }

        // optional: a book can be unclassified
        public int? GenreId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Range(0, 5)]
        public double? Rating { get; set; }
    }
}
