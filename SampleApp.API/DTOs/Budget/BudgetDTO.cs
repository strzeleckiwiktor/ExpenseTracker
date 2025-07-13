namespace ExpenseTracker.API.DTOs.Budget
{
    public record BudgetDTO
    {
        public BudgetDTO() { } 

        public long Id { get; init; } 
        public string Name { get; init; }
        public double Amount { get; init; }
        public double Remaining { get; init; }
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
    }
}