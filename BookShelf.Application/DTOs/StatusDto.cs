using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelf.Application.DTOs
{
    public class StatusDto
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; } = null!;
    }
}
