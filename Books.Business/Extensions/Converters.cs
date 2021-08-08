using AutoMapper;
using Books.Business.DataTransferObjects;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.Extensions
{
    public static class Converters
    {
        //Genres
        public static List<GenreListResponse> ConvertToListResponse(this List<Genre> genres, IMapper mapper)
        {
            return mapper.Map<List<GenreListResponse>>(genres);
        }
        public static Genre ConvertToGenre(this AddNewGenreRequest request, IMapper mapper)
        {
            return mapper.Map<Genre>(request);
        }
        public static GenreListResponse ConvertFromEntity(this Genre genre, IMapper mapper)
        {
            return mapper.Map<GenreListResponse>(genre);
        }
        public static Genre ConvertToEntity(this EditGenreRequest request, IMapper mapper)
        {
            return mapper.Map<Genre>(request);
        }

        //Authors
        public static List<AuthorListResponse> ConvertToListResponse(this List<Author> authors, IMapper mapper)
        {
            return mapper.Map<List<AuthorListResponse>>(authors);
        }
        public static AuthorListResponse ConvertFromEntity(this Author author, IMapper mapper)
        {
            return mapper.Map<AuthorListResponse>(author);
        }
        public static Author ConvertToAuthor(this AddNewAuthorRequest request, IMapper mapper)
        {
            return mapper.Map<Author>(request);
        }
        public static Author ConvertToEntity(this EditAuthorRequest request, IMapper mapper)
        {
            return mapper.Map<Author>(request);
        }

        //Publishers 
        public static List<PublisherListResponse> ConvertToListResponse(this List<Publisher> publishers , IMapper mapper)
        {
            return mapper.Map<List<PublisherListResponse>>(publishers);
        }
        public static PublisherListResponse ConvertFromEntity(this Publisher publisher, IMapper mapper)
        {
            return mapper.Map<PublisherListResponse>(publisher);
        }
        public static Publisher ConvertToPublisher(this AddNewPublisherRequest request, IMapper mapper)
        {
            return mapper.Map<Publisher>(request);
        }
        public static Publisher ConvertToEntity(this EditPublisherRequest request, IMapper mapper)
        {
            return mapper.Map<Publisher>(request);
        }

        //Books
        public static List<BookListResponse> ConvertToListResponse(this List<Book> books, IMapper mapper)
        {
            return mapper.Map<List<BookListResponse>>(books);
        }
        public static BookListResponse ConvertFromEntity(this Book book, IMapper mapper)
        {
            return mapper.Map<BookListResponse>(book);
        }
        public static Book ConvertToBook(this AddNewBookRequest request, IMapper mapper)
        {
            return mapper.Map<Book>(request);
        }

    }
}
