using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Fluent_Book
    {
        //[Key]
        public int BookId { get; set; }
        public required string Title { get; set; }
        //[MaxLength(20)]
        //[Required]
        public required string ISBN {  get; set; }
        public decimal Price { get; set; }
        //[NotMapped]
        public string PriceRange { get; set; }
        public virtual Fluent_BookDetail BookDetail { get; set; }
        public int Publisher_Id { get; set; }
        public virtual Fluent_Publisher Publisher { get; set; }
        //public List<Fluent_Author> Authors { get; set; }
        public virtual List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
    }
}
