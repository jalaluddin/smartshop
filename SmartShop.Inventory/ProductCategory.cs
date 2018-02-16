using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductCategory : Entity 
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ProductCategory ParentCatgory { get; set; }

    }
}
