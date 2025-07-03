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

            if (expense == null)
            {
                return NotFound();
            }

            var expenseDTO = mapper.Map<ExpenseDTO>(expense);

            return Ok(expenseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseDTO createExpenseDTO)
        {
            try
            {
                var expense = mapper.Map<Expense>(createExpenseDTO);

                var id = await expenseService.Create(expense);

                return CreatedAtAction(nameof(GetById), new { id }, null);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(long id, [FromBody] ExpenseDTO expenseDTO)
        //{
        //    var existingExpense = await repository.GetByIdAsync(id);

        //    if (existingExpense == null)
        //    {
        //        return NotFound();
        //    }

        //    existingExpense.Amount = expenseDTO.Amount;
        //    existingExpense.CategoryId = expenseDTO.CategoryId;

        //    var updatedExpense = await repository.UpdateAsync(existingExpense);

        //    return Ok(updatedExpense);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(long id)
        //{
        //    var existingExpense = await repository.GetByIdAsync(id);

        //    if (existingExpense == null)
        //    {
        //        return NotFound();
        //    }

        //    await repository.DeleteAsync(existingExpense);

        //    return NoContent();
        //}
    }
}
