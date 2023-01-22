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
            return photo;
        }

        [HttpPost]
        public ActionResult<Photo> Post([FromBody] PhotoDto temp)
        {
            if (ModelState.IsValid)
            {
                Photo photo = new Photo();
                photo.Id = temp.Id;
                photo.Nazwa = temp.Nazwa;
                photo.Opis = temp.Opis;
                photo.Miejsce = temp.Opis;
                photo.User = temp.User;
                photo.Comments = temp.Comments;
                photo.FileName = temp.FileName;
                photo.Likes = temp.Likes;
                photo.PhotoPath = null;

                int id = _photosService.Save(photo);
                return Created($"/api/photosapi/{id}", photo);
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult<Photo> Put([FromBody] PhotoDto temp)
        {
            if (ModelState.IsValid)
            {
                Photo photo = new Photo();
                photo.Id = temp.Id;
                photo.Nazwa = temp.Nazwa;
                photo.Opis = temp.Opis;
                photo.Miejsce = temp.Opis;
                photo.User = temp.User;
                photo.Comments = temp.Comments;
                photo.FileName = temp.FileName;
                photo.Likes = temp.Likes;
                photo.PhotoPath = null;

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
        public ActionResult<Photo> Delete(int id)
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
