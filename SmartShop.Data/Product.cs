using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Data
{
    public class Product : Entity
    {
        //public Guid ID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
