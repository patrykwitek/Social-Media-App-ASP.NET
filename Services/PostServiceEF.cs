using aplikacja_zdjecia_z_wakacji.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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

        public bool Update(Post post)
        {
            try
            {
                var find = _context.Photos.Find(post.Id);
                if (find is not null)
                {
                    find.Opis = post.Opis;
                    find.Miejsce = post.Miejsce;
                    find.User = post.User;
                    find.Data = post.Data;
                    find.Nazwa = post.Nazwa;
                    find.Photo = post.Photo;

                    find.Comments = post.Comments;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public Post? FindBy(int? id)
        {
            return id is null ? null : _context.Photos.Find(id);
        }

        public Post? FindByIdWithComments(int? id)
        {
            Post? find = _context.Photos.Include(p => p.Comments).Where(p => p.Id == id).FirstOrDefault();
            return id is null ? null : find;
        }

        public ICollection<Post> FindAll()
        {
            return _context.Photos.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public int AddCommentToPost(Comment comment, int id) // id odnosi się do posta
        {
            Post? find = _context.Photos.Include(p=>p.Comments).Where(p=>p.Id == id).FirstOrDefault();
            if (find is null) return -1;

            //comment.Post = find;
            //_context.Comments.Add(comment);
            //_context.SaveChanges();

            find.Comments.Add(comment);
            _context.Photos.Update(find);

            _context.SaveChanges();

            return comment.Id;
        }
    }
}
