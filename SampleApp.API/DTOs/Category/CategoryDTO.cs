using System.ComponentModel.DataAnnotations;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.API.DTOs.Category
{
    public record CategoryDTO(
        long Id, 
        string Name
    );
    
}
