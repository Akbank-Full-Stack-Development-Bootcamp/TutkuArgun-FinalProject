﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Business.DataTransferObjects
{
    public class EditPublisherRequest
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
