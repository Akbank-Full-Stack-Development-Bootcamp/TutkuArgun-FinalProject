using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class AddNewGenreRequest
    {
        [Required(ErrorMessage = "Tür adını belirtiniz.")]
        public string Name { get; set; }
    }
}
