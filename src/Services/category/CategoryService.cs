using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Entity;
using src.Repository;
using static src.DTO.CategoryDTO;

// Service:
// Role: Contains the business logic of the application. It bridges the controller and the repository.

namespace src.Services.category
{
    public class CategoryService : ICategoryService // CategoryService implements from ICategoryService
    {

        // fields
        protected readonly CategoryRepository _categoryRepo;
        protected readonly IMapper _mapper;

        // Constructor for DI (Dependency Injection)
        public CategoryService(CategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        // Create new Category Asynchronously
        public async Task<CategoryReadDto> CreateOneAsync(CategoryCreateDto createDto)
        {
            var category = _mapper.Map<CategoryCreateDto, Category>(createDto);

            var categoryCreated = await _categoryRepo.CreateOneAsync(category);

            return _mapper.Map<Category, CategoryReadDto>(categoryCreated);

        }

        // Get all categories Asynchronously
        public async Task<List<CategoryReadDto>> GetAllAsync()
        {
            var categoryList = await _categoryRepo.GetAllAsync();
            return _mapper.Map<List<Category>, List<CategoryReadDto>>(categoryList);
        }

        // Get category by Id Asynchronously
        public async Task<CategoryReadDto> GetByIdAsync(Guid id)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);

            // Check if the category was not found
            // if (foundCategory == null)
            // {
            // Throw an exception 
            // throw new Exception($"Category with ID {id} not found.");
            // }

            return _mapper.Map<Category, CategoryReadDto>(foundCategory);

        }

        // Delete cart by Id Asynchronously
        public async Task<bool> DeleteOneAsync(Guid id)
        {

            // find the category id
            var foundCategory = await _categoryRepo.GetByIdAsync(id);
            bool isDeleted = await _categoryRepo.DeleteOneAsync(foundCategory);

            if (isDeleted)
            {
                return true;
            }
            return false;
        }

        // Update category Asynchronously
        public async Task<bool> UpdateOneAsync(Guid id, CategoryUpdateDto updateDto)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);

            if (foundCategory == null)
            {
                return false;
            }

            _mapper.Map(updateDto, foundCategory);
            return await _categoryRepo.UpdateOneAsync(foundCategory);

        }

    } // end class 
} // end namespace