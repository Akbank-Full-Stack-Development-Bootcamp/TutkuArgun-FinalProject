using Books.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business
{
    public interface IGenreService
    {
        IList<GenreListResponse> GetAllGenres();
        int AddGenre(AddNewGenreRequest request);
        GenreListResponse GetGenresById(int id);
        int UpdateGenre(EditGenreRequest request);
        void DeleteGenre(int id);
    }
}
