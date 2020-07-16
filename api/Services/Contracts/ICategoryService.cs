
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Extension;
using Store.Models;

namespace Store.Services.Contract
{
    public interface ICategoryService
    {
        Task<ApiResponse<Category>> Find(int id);
        Task<ApiResponse<List<Category>>> GetAll();
        Task<ApiResponse<Category>> Save(Category category);
        Task<ApiResponse<Category>>  Update(Category category);
        Task<ApiResponse<Category>>  Delete(Category category);
    }
}