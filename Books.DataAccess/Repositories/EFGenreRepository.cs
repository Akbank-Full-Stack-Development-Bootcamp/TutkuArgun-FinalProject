using Books.DataAccess.Data;
using Books.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public class EFGenreRepository : IGenreRepository
    {
        private BooksDbContext db;

        public EFGenreRepository(BooksDbContext booksDbContext)
        {
            this.db = booksDbContext;
        }
        public Genre Add(Genre entity)
        {
            db.Genres.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Genres.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Genre> GetAll()
        {
            return db.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return db.Genres.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IList<Genre> GetWithCriteria(Func<Genre, bool> criteria)
        {
            return db.Genres.Where(criteria).ToList();
        }

        public Genre Update(Genre entity)
        {
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
    }
}
