using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
   public class AddNewAuthorRequest
    {
        [Required(ErrorMessage = "Yazar adını belirtiniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Yazar soyadını belirtiniz.")]
        public string LastName { get; set; }
    }
}
