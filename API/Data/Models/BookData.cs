using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class BookData
    {
        public Guid BookId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Author { get; set; }
        public required string Publisher { get; set; }
    }
}