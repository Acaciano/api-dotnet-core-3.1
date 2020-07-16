using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Extension;
using Store.Models;
using Store.Repository.Contract;
using Store.Services.Contract;

namespace Store.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<Category>> Find(int id)
        {
            Category category = await _categoryRepository.Find(id);
            
            if(category != null) return category.ResultSuccess();

            return new Category().ResultError(string.Empty);
        }

        public async Task<ApiResponse<List<Category>>> GetAll()
        {
            List<Category> categories = await _categoryRepository.GetAll();
            return categories.ResultSuccess();
        }

        public async Task<ApiResponse<Category>>  Save(Category category)
        {
            Category findByTitle = await _categoryRepository.GetByTitle(category.Title);

            if(findByTitle != null) return findByTitle.ResultError($"Já existe uma categoria com o Title: {category.Title}");

            await _categoryRepository.Save(category);
            return category.ResultSuccess();
        }

        public async Task<ApiResponse<Category>>  Update(Category category)
        {
            Category findDb = await _categoryRepository.Find(category.Id);

            if(findDb == null)  return category.ResultError($"Não foi encontrado nenhuma categoria para o ID: {category.Id}");
            
            Category findByTitle = await _categoryRepository.GetByTitle(category.Title);

            if(findByTitle != null && findByTitle.Id != category.Id) return findByTitle.ResultError($"Já existe uma categoria com o Title: {category.Title}");

            findDb.Title = category.Title;

            await _categoryRepository.Update(findDb);

            return findDb.ResultSuccess();
        }

        public async Task<ApiResponse<Category>>  Delete(Category category)
        {
            await _categoryRepository.Delete(category);

            return category.ResultSuccess();
        }
    }
}