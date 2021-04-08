using System.Collections.Generic;
using artists.Models;
using artists.Services;
using Microsoft.AspNetCore.Mvc;

namespace artists.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {

        private readonly ArtistsService _service;

        public ArtistsController(ArtistsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Artist>> GetAllArtists()
        {
            try
            {
                return Ok(_service.GetAllArtists());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Artist> CreateArtist([FromBody] Artist newArtist)
        {
            try
            {
                return Ok(_service.CreateArtist(newArtist));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> GetArtistById(int id)
        {
            try
            {
                return Ok(_service.GetArtistById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Artist> EditArtist([FromBody] Artist editedArtist, int id)
        {
            try
            {
                editedArtist.Id = id;
                return Ok(_service.EditArtist(editedArtist));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Artist> DeleteArtist(int id)
        {
            try
            {
                return Ok(_service.DeleteArtist(id));     
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}