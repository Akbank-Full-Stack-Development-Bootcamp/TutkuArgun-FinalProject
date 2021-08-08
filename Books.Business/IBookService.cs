using Books.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public interface IBookService
    {
        IList<BookListResponse> GetAllBooks();
        BookListResponse GetBookById(int id);
        int AddBook(AddNewBookRequest request);
    }
}
