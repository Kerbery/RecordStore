using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.DTOs.Artist;
using RecordStore.Core.Extensions;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistServices _artistServices;

        public ArtistsController(IArtistServices artistServices)
        {
            _artistServices = artistServices;
        }

        // GET: api/<ArtistsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetArtistDTO>>> GetAsync()
        {
            var artists = (await _artistServices.GetAllAsync())
                .Select(a => a.AsDTO());

            return Ok(artists);
        }

        // GET api/<ArtistsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetArtistDTO>> GetAsync(Guid id)
        {
            var artist = (await _artistServices.GetAsync(id)).AsDTO();

            return Ok(artist);
        }

        // POST api/<ArtistsController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromForm] CreateArtistDTO createArtistDTO)
        {
            var createdArtist = await _artistServices.CreateAsync(createArtistDTO);

            return CreatedAtAction(nameof(GetAsync), new { id = createdArtist.Id }, createdArtist.AsDTO());
        }

        // PUT api/<ArtistsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromForm] UpdateArtistDTO updateArtistDTO)
        {
            await _artistServices.UpdateAsync(id, updateArtistDTO);
            return Ok();
        }

        // DELETE api/<ArtistsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _artistServices.DeleteAsync(id);
            return Ok();
        }
    }
}
