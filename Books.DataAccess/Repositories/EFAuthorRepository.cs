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
    public class EFAuthorRepository : IAuthorRepository
    {
        private BooksDbContext db;

        public EFAuthorRepository(BooksDbContext booksDbContext)
        {
            this.db = booksDbContext;
        }

        public Author Add(Author entity)
        {
            db.Authors.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Authors.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return db.Authors.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IList<Author> GetWithCriteria(Func<Author, bool> ctiteria)
        {
            throw new NotImplementedException();
        }

        public Author Update(Author entity)
        {
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
    }
}
