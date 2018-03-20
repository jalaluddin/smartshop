using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Foundation
{
    [Table("AspNetRoles")]
    public class Role
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
