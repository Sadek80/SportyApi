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

        public DbSet<Sport> Sports { get; set; }
        public DbSet<Level> Levels{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }
        public DbSet<UserCreditCard> CreditCards { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<TrainingProgram> TrainingPrograms{ get; set; }
        public DbSet<ReservedProgram> ReservedPrograms{ get; set; }
        public DbSet<UsersInterests> UsersInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderItem>()
             .HasKey(o => new { o.OrderId, o.ProductId });

            builder.Entity<ReservedProgram>()
                .HasKey(r => new { r.UserId, r.TrainingProgramId });

            builder.Entity<UsersInterests>().HasKey(u => new { u.SportId, u.UserId });

            //Seeding

            builder.Entity<TrainingProgram>().HasData(new TrainingProgram
            {
                TrainingProgramId = Guid.NewGuid(),
                SportId = new Guid("2eb7d589-7dc9-453f-9a8d-00f53ef9449b"),
                Name = "Mass Building Hypertrophy Workout",
                Provider = "Gold's Gym",
                DescriptionMinimized = "This program will help intermediate trainees gain size and " +
                "strength. Rest-pause set, drop sets, and negatives will kick your muscle gains into high gear!",
                Description = "That would be the best split, but let’s face facts. There are a lot of you that have" +
                " jobs that don’t allow this to happen, so here’s what you need to know. " +
                "The only rule I suggest you follow is that you don’t train for more than three days in a row before " +
                "taking a day off. Two would be best, but if you must train a third consecutive day, " +
                "go for it. I don’t suggest you do this normally. For more info, please Enroll and we " +
                "will contact you",
                ImageUrl = "Programs/Gym/MassBuildingHypertrophyWorKout.PNG",
                LevelId = new Guid("0dfe7a76-f899-4b8c-aa86-495c70ff3959"),
                Location = "Gold's Gym - Elite San Stefano",
                PricePerMonth = 3000,
            });
        }
    }
}