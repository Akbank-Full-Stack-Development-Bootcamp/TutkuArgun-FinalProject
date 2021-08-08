using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class BookListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal  Price { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public IList<BookGenre> Genres { get; set; }

    }
}
