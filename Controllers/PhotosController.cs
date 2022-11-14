using aplikacja_zdjecia_z_wakacji.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace aplikacja_zdjecia_z_wakacji.Controllers
{
    public class PhotosController : Controller
    {
        public static List<Post> posts = new List<Post>();

        public static int liczba_postow = 0;
        public IActionResult Index()
        {
            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Id = liczba_postow;
                post.Data = DateTime.Now;
                liczba_postow++;
                posts.Add(post);
                return View("index", posts);
            }
            else
            {
                return View();
            }
        }
        
        public IActionResult Details([FromRoute] int id)
        {
            Post post_szczegolowy = posts.FirstOrDefault(e => e.Id == id);

            if (post_szczegolowy == null)
            {
                return NotFound();
            }

            return View(post_szczegolowy);
        }
    }
}