
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repository.Contract
{
    public interface ICategoryRepository
    {
        Task<Category> Find(int id);
        Task<List<Category>> GetAll();
        Task Save(Category category);
        Task Update(Category category);
        Task Delete(Category category);
        Task<Category> GetByTitle(string title);
    }
}