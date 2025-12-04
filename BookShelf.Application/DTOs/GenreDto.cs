using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf.Application.DTOs
{
    public class GenreDto
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; } = null!;
    }
}
