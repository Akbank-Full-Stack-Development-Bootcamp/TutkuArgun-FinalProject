using Books.DataAccess.Data;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        //private BooksDbContext db;

        //public EFUserRepository(BooksDbContext booksDbContext)
        //{
        //    this.db = booksDbContext;
        //}
        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        private List<User> users = new List<User>
           {
               new User { Email="abc@abc.com", Password="123", UserName="tutku", Role="Admin"},
               new User { Email="def@abc.com", Password="258", UserName="ozge", Role="Editor"},
               new User { Email = "zxc@abc.com", Password = "369", UserName="sedef", Role="User" },
           };
        public IList<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetWithCriteria(Func<User, bool> criteria)
        {
            return users.Where(criteria).ToList();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
