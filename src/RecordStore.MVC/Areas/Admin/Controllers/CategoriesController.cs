using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.DTOs.Category;
using RecordStore.Core.Extensions;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDTO>>> GetAsync()
        {
            var categories = (await _categoryServices.GetAllAsync())
                .Select(category => category.AsDTO());

            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDTO>> GetAsync(Guid id)
        {
            var category = (await _categoryServices.GetAsync(id)).AsDTO();

            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] CreateCategoryDTO createCategoryDTO)
        {
            var createdCategory = await _categoryServices.CreateAsync(createCategoryDTO);

            return CreatedAtAction(nameof(GetAsync), new { id = createdCategory.Id }, createdCategory.AsDTO());
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromForm] UpdateCategoryDTO updateCategoryDTO)
        {
            await _categoryServices.UpdateAsync(id, updateCategoryDTO);
            return Ok();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _categoryServices.DeleteAsync(id);
            return Ok();
        }
    }
}
