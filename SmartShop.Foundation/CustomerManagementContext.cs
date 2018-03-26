using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Foundation
{
    public class CustomerManagementContext : DbContext
    {
        public CustomerManagementContext()
            : base("DefaultConnection")
        {
            //Database.SetInitializer<CustomerManagementContext>(null);
        }

        public DbSet<Customer> Customer { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder
                .Entity<Customer>()
                .HasMany<Role>(x => x.Roles)
                .WithMany(x => x.Customers)
                .Map(y => 
                    y.MapLeftKey("UserId")
                    .MapRightKey("RoleId")
                    .ToTable("AspNetUserRoles")
                );
        }
    }
}
