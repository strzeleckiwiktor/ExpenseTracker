using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.API.DTOs.Category;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.Exceptions;
using ExpenseTracker.API.DTOs.Expense;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(
        ICategoryService categoryService,
        IExpenseService expenseService,
        IMapper mapper
        ) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.GetAll();
            var categoryDTOs = mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return Ok(categoryDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var category = await categoryService.GetById(id);
            var categoryDTO = mapper.Map<CategoryDTO>(category);
            return Ok(categoryDTO);
        }

        [HttpGet("{id}/expenses")]
        public async Task<IActionResult> GetExpensesByCategory(long id)
        {
            var expenses = await expenseService.GetExpensesByCategory(id);
            var expenseDTOs = mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
            return Ok(expenseDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            var category = mapper.Map<Category>(createCategoryDTO);
            long id = await categoryService.Create(category);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            await categoryService.Update(id, updateCategoryDTO.Name);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await categoryService.Delete(id);
            return Ok();
        }
    }
}
