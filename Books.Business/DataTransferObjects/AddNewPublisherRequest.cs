using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
   public class AddNewPublisherRequest
    {
        [Required(ErrorMessage = "Yayınevi adını belirtiniz.")]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
