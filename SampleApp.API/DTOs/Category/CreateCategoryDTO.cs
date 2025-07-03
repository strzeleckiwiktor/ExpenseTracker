using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.DTOs.Category
{
    public record CreateCategoryDTO(
        string Name
    );
}
