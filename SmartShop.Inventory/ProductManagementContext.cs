using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Inventory
{
    public class ProductManagementContext : DbContext 
    {
        public ProductManagementContext()
            :base("DefaultConnection")
        {
            //Database.SetInitializer<ProductManagementContext>(null);
        }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder
                .Entity<Product>()
                .HasMany<ProductImage>(x => x.ProductImages).WithOptional().HasForeignKey(y => y.Product_ID).WillCascadeOnDelete();

            modelBuilder
                .Entity<Product>()
                .HasMany<ProductType>(x => x.ProductTypes).WithOptional().HasForeignKey(y => y.Product_ID).WillCascadeOnDelete();

            modelBuilder
                .Entity<Product>()
                .HasMany<ProductAdditionalInformation>(x => x.ProductAdditionalInformations).WithOptional().HasForeignKey(y => y.Product_ID).WillCascadeOnDelete();
        }
    }
}
