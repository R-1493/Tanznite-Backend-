using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Services.category;
using src.Utils;
using static src.DTO.CategoryDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriesController : ControllerBase
    {
        protected readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService service)
        {
            _categoryService = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryReadDto>> CreateOne(CategoryCreateDto createDto)
        {
            var categoryCreated = await _categoryService.CreateOneAsync(createDto);
            return Ok(categoryCreated);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryReadDto>> UpdateOne(
            Guid id,
            CategoryUpdateDto updateDto
        )
        {
            var categoryUpdated = await _categoryService.UpdateOneAsync(id, updateDto);
            if (categoryUpdated == null)
            {
                return NotFound();
            }
            return Ok(categoryUpdated);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryReadDto>>> GetAll()
        {
            var categoryList = await _categoryService.GetAllAsync();
            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReadDto>> GetById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] //--> For admins
        public async Task<ActionResult> DeleteOne(Guid CategoryId)
        {
            var categoryDeleted = await _categoryService.DeleteOneAsync(CategoryId);
            if (categoryDeleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("Filter")]
        public async Task<ActionResult<List<CategoryReadDto>>> FilterJewelry(
            [FromQuery] CategoryFilterationOptions categoryFilter,
            [FromQuery] PaginationOptions paginationOptions
        )
        {
            var categoryN = await _categoryService.GetAllByFilterationAsync(
                categoryFilter,
                paginationOptions
            );
            return Ok(categoryN);
        }
    } // end class
} // end namespace
