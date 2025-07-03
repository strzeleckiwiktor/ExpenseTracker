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
            var category = await categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDTO = mapper.Map<CategoryDTO>(category);

            return Ok(categoryDTO);
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
            var updatedCategory = await categoryService.Update(id, updateCategoryDTO.Name);

            if (updatedCategory == null)
            {
                return NotFound();
            }

            var updatedCategoryDTO = mapper.Map<Category>(updatedCategory);
            return Ok(updatedCategory);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(long id)
        //{
        //    var existingCategory = await categoryService.GetById(id);

        //    if (existingCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    await categoryService.Delete(existingCategory);

        //    return NoContent();
        //}
    }
}
