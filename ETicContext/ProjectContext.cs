using ETicModels.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ETicContext
{
   public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = ("Server=HPPRO4520\\SQLExpress;Database=Odev;Integrated Security=true;");
        }
        public DbSet<Category> Categories;
        public DbSet<Product> Products;
        public DbSet<AppUser> Users;
        public DbSet<Comment> Comments;
        public DbSet<Order> Orders;
        public DbSet<Order> Order_Details;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ID);
            modelBuilder.Entity<Category>().HasKey(c => c.ID);
            modelBuilder.Entity<AppUser>().HasKey(a => a.ID);
            modelBuilder.Entity<Comment>().HasKey(c => c.ID);
           
            

            modelBuilder.Entity<Comment>().Property(p => p.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Category>().Property(p => p.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Product>().Property(p => p.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<AppUser>().Property(p => p.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Order>()
                     .HasMany(e => e.Order_Details)
                     .WithRequired(e => e.Order)
                     .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>().HasRequired(p => p.Product).WithMany(c => c.Comments).HasForeignKey(p => p.ProductID).WillCascadeOnDelete(true); 

            modelBuilder.Entity<Product>().HasRequired(c => c.Category).WithMany(p => p.Products).HasForeignKey(p=>p.CategoryID).WillCascadeOnDelete(true);

            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithRequired(c => c.Category).HasForeignKey(c => c.CategoryID);

            modelBuilder.Entity<AppUser>().HasMany(c => c.Comments);
            modelBuilder.Entity<Product>().HasMany(c => c.Comments);

      
            base.OnModelCreating(modelBuilder);
        }



    }
}
