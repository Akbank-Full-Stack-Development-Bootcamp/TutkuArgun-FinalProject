using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string bookCover { get; set; }
        public int? GenreId { get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }

        //Navigation Properties
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual IList<BookGenre> Genres { get; set; }
    }
}
