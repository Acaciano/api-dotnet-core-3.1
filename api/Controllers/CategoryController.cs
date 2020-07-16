using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Extension;
using Store.Models;
using Store.Services.Contract;

namespace Store.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ApiBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Response(await _categoryService.Find(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Response(await _categoryService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category model)
        {
            if(ModelState.IsValid)
            {
                return Response(await _categoryService.Save(model));
            }

            return ResponseError(ModelState);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category model)
        {
            if(ModelState.IsValid)
            {
                model.Id = id;
                return Response(await _categoryService.Update(model));
            }

            return ResponseError(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ApiResponse<Category> category = await _categoryService.Find(id);
                
            if(category != null && category.Success)
                return Response(await _categoryService.Delete(category.Data));

            return ResponseError("Categoria não encontrada!");
        }
    }
}