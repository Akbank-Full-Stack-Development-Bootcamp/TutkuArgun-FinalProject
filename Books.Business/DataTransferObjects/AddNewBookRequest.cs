using Books.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class AddNewBookRequest
    {
        [Required(ErrorMessage = "Kitap adını belirtiniz.")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string bookCover { get; set; }
        public AuthorListResponse Author { get; set; }
        //public Publisher Publisher { get; set; }
        //public IList<BookGenre> Genres { get; set; }
    }
}
