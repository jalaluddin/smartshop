﻿using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Foundation
{
    [Table("AspNetUsers")]
    public class Customer
    {
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
