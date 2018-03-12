using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Foundation
{
    public class Customer :Entity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
