using ExpenseTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Persistence
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
    }
}
