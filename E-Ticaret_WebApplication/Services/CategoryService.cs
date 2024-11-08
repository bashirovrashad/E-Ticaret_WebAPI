using E_Ticaret_WebApplication.DTOs;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;

namespace E_Ticaret_WebApplication.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Select(a => new CategoryDto { Id = a.Id, Name = a.Name });
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return category != null ? new CategoryDto { Id = category.Id, Name = category.Name } : null;
        }

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category { Name = categoryDto.Name };
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category { Id = categoryDto.Id, Name = categoryDto.Name };
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
