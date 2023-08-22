using AppleStore.Application.Input.InputModels;
using AppleStore.Application.Input.Repositories;
using AppleStore.Application.Output.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace AppleStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryReadService _categoryReadService;
        private readonly ICategoryWriteService _CategoryWriteService;

        public CategoriesController(ICategoryReadService categoryReadService, ICategoryWriteService categoryWriteService)
        {
            _categoryReadService = categoryReadService;
            _CategoryWriteService = categoryWriteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryReadService.ReadAllAsync();

            return Ok(categories);

        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var category = await _categoryReadService.GetByIdAsync(id);
            if (category is null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryInputModel model)
        {
            var result = await _CategoryWriteService.AddAsync(model);
            if (result != null)
            {
                return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CategoryInputModel model)
        {
            var result = await _CategoryWriteService.UpdateAsync(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            var result = await _CategoryWriteService.Delete(id);


        }
    }
}
