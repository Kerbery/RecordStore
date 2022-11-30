using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.DTOs.Style;
using RecordStore.Core.Extensions;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylesController : ControllerBase
    {
        private readonly IStyleServices _styleServices;

        public StylesController(IStyleServices styleServices)
        {
            _styleServices = styleServices;
        }

        // GET: api/<StylesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStyleDTO>>> GetAsync()
        {
            var styles = (await _styleServices.GetAllAsync())
                .Select(s => s.AsDTO());

            return Ok(styles);
        }

        // GET api/<StylesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetStyleDTO>> GetAsync(Guid id)
        {
            var style = (await _styleServices.GetAsync(id)).AsDTO();

            return Ok(style);

        }

        // POST api/<StylesController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] CreateStyleDTO CreateStyleDTO)
        {
            var createdStyle = await _styleServices.CreateAsync(CreateStyleDTO);

            return CreatedAtAction(nameof(GetAsync), new { id = createdStyle.Id }, createdStyle.AsDTO());
        }

        // PUT api/<StylesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromForm] UpdateStyleDTO updateGenreDTO)
        {
            await _styleServices.UpdateAsync(id, updateGenreDTO);
            return Ok();
        }

        // DELETE api/<StylesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _styleServices.DeleteAsync(id);
            return Ok();
        }
    }
}
