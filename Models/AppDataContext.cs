using SportyApi.Models.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Models
{
    public class AppDataContext : IdentityDbContext<ApplicationUser>
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShppingCartItems { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Level> Levels{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }
        public DbSet<UserCreditCard> CreditCards { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<TrainingProgram> TrainingPrograms{ get; set; }
        public DbSet<ReservedProgram> ReservedPrograms{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderItem>()
             .HasKey(o => new { o.OrderId, o.ProductId });

            builder.Entity<ReservedProgram>()
                .HasKey(r => new { r.UserId, r.TrainingProgramId });

            //Seeding
        }
    }
}
