using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.DTOs.Release;
using RecordStore.Core.Extensions;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleasesController : ControllerBase
    {
        private readonly IReleaseServices _releaseServices;

        public ReleasesController(IReleaseServices releaseServices)
        {
            _releaseServices = releaseServices;
        }

        // GET: api/<ReleasesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetReleaseDTO>>> GetAsync()
        {
            var releases = (await _releaseServices.GetAllAsync())
                .Select(r => r.AsDTO());

            return Ok(releases);
        }

        // GET api/<ReleasesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetReleaseDTO>> GetAsync(Guid id)
        {
            var release = (await _releaseServices.GetAsync(id)).AsDTO();

            return Ok(release);
                
        }

        // POST api/<ReleasesController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] CreateReleaseDTO createReleaseDTO)
        {
            var createdRelease = await _releaseServices.CreateAsync(createReleaseDTO);

            return CreatedAtAction(nameof(GetAsync), new { id = createdRelease.Id }, createdRelease.AsDTO());
        }

        // PUT api/<ReleasesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] UpdateReleaseDTO updateReleaseDTO)
        {
            await _releaseServices.UpdateAsync(id, updateReleaseDTO);
            return Ok();
        }

        // DELETE api/<ReleasesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _releaseServices.DeleteAsync(id);
            return Ok();
        }
    }
}
