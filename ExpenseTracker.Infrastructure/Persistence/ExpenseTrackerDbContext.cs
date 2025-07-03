using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Persistence
{
    internal class ExpenseTrackerDbContext : DbContext
    {
        public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options) : base(options)
        {

        }

        internal DbSet<Expense> Expenses { get; set; }
        internal DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Expenses)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();

            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Food"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Leisure"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Health"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Housing"
                }
            };

            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}
