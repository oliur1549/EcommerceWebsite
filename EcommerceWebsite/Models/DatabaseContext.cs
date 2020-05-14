using EcommerceWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsite.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<RoleAccount>()
                .HasKey(pc => new { pc.RoleId, pc.AccountId });

            builder.Entity<RoleAccount>()
                .HasOne(d => d.Account)
                .WithMany(c => c.RoleAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleAccount_Account");

            builder.Entity<RoleAccount>()
                .HasOne(d => d.Role)
                .WithMany(c => c.RoleAccounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleAccount_Role");

            builder.Entity<Category>()
                .HasOne(d => d.Parent)
                .WithMany(c => c.InverseParents)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Category_Category");

            builder.Entity<Product>()
                .HasOne(d => d.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_Product");

            builder.Entity<Photo>()
                .HasOne(d => d.Product)
                .WithMany(c => c.Photos)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Photo");

            base.OnModelCreating(builder);
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SlideShow> SlideShows { get; set; }
        public DbSet<RoleAccount> RoleAccounts { get; set; }
    }
}
