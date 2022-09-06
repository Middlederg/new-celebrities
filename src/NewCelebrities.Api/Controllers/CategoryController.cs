using Microsoft.AspNetCore.Mvc;
using NewCelebrities.Api.Services;

namespace NewCelebrities.Api
{
    [ApiController]
    [Route(Shared.CategoriesEndpoints.Base)]
    public class CategoryController : ControllerBase
    {
        private readonly FileRepository repository;

        public CategoryController(FileRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Shared.GetCategoriesResponse> GetAll()
        {
            var categories = repository.CategoryList();
            return Ok(new Shared.GetCategoriesResponse()
            {
                Categories = categories,
            });
        }
    }
}
