using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Domain.Entities
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
    }
}
