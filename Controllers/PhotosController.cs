using aplikacja_zdjecia_z_wakacji.Models;
using aplikacja_zdjecia_z_wakacji.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

namespace aplikacja_zdjecia_z_wakacji.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IPostService _postService;
        public PhotosController(AppDbContext context, IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            return View(_postService.FindAll());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Data = DateTime.Now;
                _postService.Save(post);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        
        public IActionResult Details([FromRoute] int id)
        {
            Post post_szczegolowy = _postService.FindBy(id);

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
                _postService.AddCommentToPost(comment, comment.PostId);
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }
        public IActionResult SeeComments([FromRoute] int id)
        {
            Post post = _postService.FindByIdWithComments(id);
            if (post == null) return NotFound();
            return View(post);
        }
    }
}