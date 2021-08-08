using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Author : IEntity
    {
        public int Id { get ; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual IList<Book> Books { get; set; }
    }
}
