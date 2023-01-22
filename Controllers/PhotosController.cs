using aplikacja_zdjecia_z_wakacji.Models;
using aplikacja_zdjecia_z_wakacji.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace aplikacja_zdjecia_z_wakacji.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IPhotosService _photosService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PhotosController(AppDbContext context, IPhotosService photosService, IWebHostEnvironment hostEnvironment)
        {
            _photosService = photosService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_photosService.FindAll());
        }

        public IActionResult PagedIndex([FromQuery] int page = 1, [FromQuery] int size = 3)
        {
            return View(_photosService.FindPage(page, size));
        }

        [Authorize(Roles = "admin")]
        public IActionResult Statistics()
        {
            return View(_photosService.FindStatistics());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Photo post)
        {
            if (ModelState.IsValid)
            {
                post.Data = DateTime.Now;

                string root = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(post.PhotoPath.FileName);
                string extension = Path.GetExtension(post.PhotoPath.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                post.FileName = fileName;
                string path = Path.Combine(root + "/Images", fileName);
                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    await post.PhotoPath.CopyToAsync(fileStream);
                }

                _photosService.Save(post);
                return RedirectToAction(nameof(PagedIndex));
            }
            else
            {
                return View(post);
            }
        }
        
        public IActionResult Details([FromRoute] int id)
        {
            Photo post_szczegolowy = _photosService.FindBy(id);

            if (post_szczegolowy == null)
            {
                return NotFound();
            }

            return View(post_szczegolowy);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddComment([FromRoute] int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddComment([FromForm] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Data = DateTime.Now;
                _photosService.AddCommentToPost(comment, comment.PhotoId);
                return RedirectToAction("SeeComments", new { id = comment.PhotoId });
            }
            return View(comment);
        }
        public IActionResult SeeComments([FromRoute] int id)
        {
            return View(_photosService.FindAllComments(id));
        }

        [Authorize]
        public IActionResult Like([FromRoute] int id)
        {
            Photo post = _photosService.FindByIdWithLikes(id);

            for(int i=0; i<post.Likes.Count(); i++)
            {
                if(post.Likes[i].User == User.Identity.Name)
                {
                    Like delete_like = post.Likes[i];
                    _photosService.DeleteLikeFromPost(delete_like, id);
                    return RedirectToAction(nameof(PagedIndex));
                }
            }

            Like add_like = new Like();

            add_like.User = User.Identity.Name;
            _photosService.AddLikeToPost(add_like, id);

            if (post == null) return NotFound();
            return RedirectToAction(nameof(PagedIndex));
        }

        [Authorize]
        public IActionResult LikeComment([FromRoute] int id)
        {
            Comment? comment = _photosService.FindCommentByIdWithLikes(id);
            if (comment is null) return NotFound();

            for (int i = 0; i < comment.Likes.Count(); i++)
            {
                if (comment.Likes[i].User == User.Identity.Name)
                {
                    LikeForComment delete_like = comment.Likes[i];
                    _photosService.DeleteLikeFromComment(delete_like, id);
                    return RedirectToAction("SeeComments", new { id = comment.PhotoId });
                }
            }

            LikeForComment add_like = new LikeForComment();

            add_like.User = User.Identity.Name;
            _photosService.AddLikeToComment(add_like, id);

            return RedirectToAction("SeeComments", new { id = comment.PhotoId });
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete([FromRoute] int? id)
        {
            _photosService.Delete(id);
            return RedirectToAction(nameof(Statistics));
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit([FromRoute] int? id)
        {
            Photo? photo = _photosService.FindByIdWithLikesAndComments(id);
            if (photo == null) return NotFound();

            ViewBag.Id = photo.Id;
            ViewBag.Nazwa = photo.Nazwa;
            ViewBag.Miejsce = photo.Miejsce;
            ViewBag.Opis = photo.Opis;

            return View();
        }

        [HttpPost]
        public IActionResult Edit([FromForm] PhotoTempForEdit photo)
        {
            if (ModelState.IsValid)
            {
                Photo? find = _photosService.FindByIdWithLikesAndComments(photo.Id);
                _photosService.UpdateByPhotoTemp(find, photo);
                return RedirectToAction(nameof(Statistics));
            }
            return View(photo);
        }
    }
}