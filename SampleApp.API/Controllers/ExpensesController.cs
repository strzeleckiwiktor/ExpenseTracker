using ExpenseTracker.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.API.DTOs.Expense;
using ExpenseTracker.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController(
        IExpenseService expenseService,
        IMapper mapper
        ) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await expenseService.GetAll();
            var expenseDTOs = mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
            return Ok(expenseDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var expense = await expenseService.GetById(id);
            var expenseDTO = mapper.Map<ExpenseDTO>(expense);
            return Ok(expenseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseDTO createExpenseDTO)
        {
            var expense = mapper.Map<Expense>(createExpenseDTO);
            var id = await expenseService.Create(expense);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateExpenseDTO updateExpenseDTO)
        {
            await expenseService.Update(
                    id,
                    updateExpenseDTO.Name,
                    updateExpenseDTO.Amount,
                    updateExpenseDTO.Description,
                    updateExpenseDTO.CategoryId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await expenseService.Delete(id);
            return Ok();
        }
    }
}
