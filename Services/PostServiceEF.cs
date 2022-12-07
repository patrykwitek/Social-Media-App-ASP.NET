using aplikacja_zdjecia_z_wakacji.Models;
using Microsoft.EntityFrameworkCore;

namespace aplikacja_zdjecia_z_wakacji.Services
{
    public class PostServiceEF : IPostService
    {
        private readonly AppDbContext _context;

        public PostServiceEF(AppDbContext context)
        {
            _context = context;
        }

        public int Save(Post book)
        {
            try
            {
                var entityEntry = _context.Photos.Add(book);
                _context.SaveChanges();
                return entityEntry.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }
        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }

            var find = _context.Photos.Find(id);
            if (find is not null)
            {
                _context.Photos.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Post? FindBy(int? id)
        {
            return id is null ? null : _context.Photos.Find(id);
        }

        public ICollection<Post> FindAll()
        {
            return _context.Photos.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
