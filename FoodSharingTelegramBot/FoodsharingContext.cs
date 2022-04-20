using FoodSharing.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.DataAccessLayer
{
    public class FoodsharingContext : DbContext
    {
        private readonly string _connectionString =
            "Data Source=USER;Initial Catalog=FoodsharingLocalDb;Integrated Security=True;";

        public FoodsharingContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User
                {
                    UserId = 1,
                    ChatId = 444343256,
                    Username = "noncredistka",
                    Firstname = "nucleus accumbens",
                    City = Enums.Cities.Batumi,
                    Language = Enums.Languages.Russian,
                    Notify = true,
                    IsAdmin = true
                }
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}
