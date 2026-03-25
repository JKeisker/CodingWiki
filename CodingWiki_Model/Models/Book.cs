using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string ISBN {  get; set; }
        public double Price { get; set; }
    }
}
