using aplikacja_zdjecia_z_wakacji.Models;
using aplikacja_zdjecia_z_wakacji.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aplikacja_zdjecia_z_wakacji.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosApiController : ControllerBase
    {
        private readonly IPhotosService _photosService;
        public PhotosApiController(IPhotosService photosService)
        {
            _photosService = photosService;
        }
        public IEnumerable<Photo> Get()
        {
            return _photosService.FindAll();
        }

        [Route("{id}")]
        public ActionResult<Photo> Get(int id)
        {
            Photo? photo = _photosService.FindByIdWithLikesAndComments(id);
            if(photo is null) return NotFound();
            return Ok(photo);
        }

        [HttpPost]
        public ActionResult<Photo> Post([FromBody] Photo photo)
        {
            if (ModelState.IsValid)
            {
                int id = _photosService.Save(photo);
                return Created($"/api/photosapi/{id}", photo);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult<Photo> Put([FromBody] Photo photo)
        {
            if (ModelState.IsValid)
            {
                if (_photosService.Update(photo))
                {
                    return Ok(photo);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_photosService.Delete(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
