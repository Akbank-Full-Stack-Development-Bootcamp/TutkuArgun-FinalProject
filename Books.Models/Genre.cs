using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Genre : IEntity
    {
        public int Id { get ; set ; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
        public virtual IList<BookGenre> Books { get; set; }
    }
}
