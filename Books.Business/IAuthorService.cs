using Books.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public interface IAuthorService
    {
        IList<AuthorListResponse> GetAllAuthors();
        AuthorListResponse GetAuthorById(int id);
        int AddAuthor(AddNewAuthorRequest request);
        void DeleteAuthor(int id);
        int UpdateAuthor(EditAuthorRequest request);
        

    }
}
