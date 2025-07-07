using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.API.DTOs.Category;
using ExpenseTracker.Application.Interfaces;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(
        ICategoryService categoryService,
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
            try
            {
                var category = await categoryService.GetById(id);
                var categoryDTO = mapper.Map<CategoryDTO>(category);
                return Ok(categoryDTO);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
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
            try
            {
                await categoryService.Update(id, updateCategoryDTO.Name);
                return Ok();
            } 
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await categoryService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
