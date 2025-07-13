using AutoMapper;
using ExpenseTracker.API.DTOs.Budget;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController(
        IBudgetService budgetService,
        IMapper mapper
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var budgets = await budgetService.GetAll();
            var budgetDTOs = mapper.Map<IEnumerable<BudgetDTO>>(budgets);
            return Ok(budgetDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var budgetDetails = await budgetService.GetById(id);
            var budgetDTO = mapper.Map<BudgetDTO>(budgetDetails);
            return Ok(budgetDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBudgetDTO createBudgetDTO)
        {
            var budget = mapper.Map<Budget>(createBudgetDTO);
            var id =  await budgetService.Create(budget);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            await budgetService.Delete(id);
            return Ok();
        }
    }
}
