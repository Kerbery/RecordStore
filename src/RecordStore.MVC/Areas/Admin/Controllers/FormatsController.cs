using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.DTOs.Format;
using RecordStore.Core.Extensions;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private readonly IFormatServices _formatServices;

        public FormatsController(IFormatServices formatServices)
        {
            _formatServices = formatServices;
        }

        // GET: api/<FormatsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFormatDTO>>> GetAsync()
        {
            var formats = (await _formatServices.GetAllAsync())
                .Select(f => f.AsDTO());

            return Ok(formats);
        }

        // GET api/<FormatsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetFormatDTO>> GetAsync(Guid id)
        {
            var format = (await _formatServices.GetAsync(id)).AsDTO();

            return Ok(format);                
        }

        // POST api/<FormatsController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] CreateFormatDTO createFormatDTO)
        {
            var createdFormat = await _formatServices.CreateAsync(createFormatDTO);

            return CreatedAtAction(nameof(GetAsync), new { id = createdFormat.Id }, createdFormat.AsDTO());
        }

        // PUT api/<FormatsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromForm] UpdateFormatDTO updateFormatDTO)
        {
            await _formatServices.UpdateAsync(id, updateFormatDTO);
            return Ok();
        }

        // DELETE api/<FormatsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _formatServices.DeleteAsync(id);
            return Ok();
        }
    }
}
