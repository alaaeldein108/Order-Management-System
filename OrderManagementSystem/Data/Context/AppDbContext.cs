using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class AppDbContext:IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
            builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
            builder.Entity<IdentityRoleClaim<string>>().Property(x => x.RoleId).HasColumnType("nvarchar(450)");
            builder.Entity<IdentityUserClaim<string>>().Property(x => x.UserId).HasColumnType("nvarchar(450)");
            builder.Entity<IdentityUserLogin<string>>().Property(x => x.UserId).HasColumnType("nvarchar(450)");

            builder.Entity<IdentityUserToken<string>>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .IsRequired();

            builder.Entity<IdentityUserClaim<string>>()
           .HasOne<ApplicationUser>()
           .WithMany()
           .HasForeignKey(t => t.UserId)
           .IsRequired();

            builder.Entity<IdentityUserLogin<string>>()
           .HasOne<ApplicationUser>()
           .WithMany()
           .HasForeignKey(t => t.UserId)
           .IsRequired();

            builder.Entity<IdentityUserRole<string>>()
           .HasOne<ApplicationUser>()
           .WithMany()
           .HasForeignKey(t => t.UserId)
           .IsRequired();

           builder.Entity<IdentityUserRole<string>>()
          .HasOne<ApplicationRole>()
          .WithMany()
          .HasForeignKey(t => t.RoleId)
          .IsRequired();

           builder.Entity<IdentityRoleClaim<string>>()
          .HasOne<ApplicationRole>()
          .WithMany()
          .HasForeignKey(t => t.RoleId)
            .IsRequired();

            builder.Entity<Order>()
           .HasOne(o => o.Customer)
           .WithMany(c => c.Orders)
           .HasForeignKey(o => o.CustomerId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Invoice>()
                .HasOne(i => i.Order)
                .WithMany()
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
