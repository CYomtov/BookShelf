using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShelf.Application.DTOs
{
    public class CreateGenreDto
    {
        [Required]
        [StringLength(100)]
        public string GenreName { get; set; } = null!;
    }
}
