using aplikacja_zdjecia_z_wakacji.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace aplikacja_zdjecia_z_wakacji.Services
{
    public class PhotosServiceEF : IPhotosService
    {
        private readonly AppDbContext _context;

        public PhotosServiceEF(AppDbContext context)
        {
            _context = context;
        }

        public int Save(Photo photo)
        {
            try
            {
                var entityEntry = _context.Photos.Add(photo);
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
            if (id is null) return false;

            //Post? find = _context.Photos.Include(p => p.Comments).Include(p => p.Likes).Where(p => p.Id == id).FirstOrDefault();

            Photo? find = _context.Photos.Find(id);

            if (find is not null)
            {
                _context.Photos.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Photo photo)
        {
            try
            {
                var find = _context.Photos.Find(photo.Id);
                if (find is not null)
                {
                    find.Opis = photo.Opis;
                    find.Miejsce = photo.Miejsce;
                    find.User = photo.User;
                    find.Data = photo.Data;
                    find.Nazwa = photo.Nazwa;
                    find.PhotoPath = photo.PhotoPath;
                    find.FileName = photo.FileName;

                    find.Comments = photo.Comments;
                    find.Likes = photo.Likes;

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

        public bool UpdateByPhotoTemp(Photo? find, PhotoTempForEdit photo)
        {
            try
            {
                if (find is not null)
                {
                    find.Opis = photo.Opis;
                    find.Miejsce = photo.Miejsce;
                    find.Nazwa = photo.Nazwa;

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

        public Photo? FindBy(int? id)
        {
            return id is null ? null : _context.Photos.Find(id);
        }

        public Photo? FindByIdWithComments(int? id)
        {
            Photo? find = _context.Photos.Include(p => p.Comments).Where(p => p.Id == id).FirstOrDefault();
            return id is null ? null : find;
        }

        public Photo? FindByIdWithLikes(int? id)
        {
            Photo? find = _context.Photos.Include(p => p.Likes).Where(p => p.Id == id).FirstOrDefault();
            return id is null ? null : find;
        }

        public Photo? FindByIdWithLikesAndComments(int? id)
        {
            Photo? find = _context.Photos.Include(p => p.Likes).Include(p => p.Comments).Where(p => p.Id == id).FirstOrDefault();
            return id is null ? null : find;
        }

        public Comment? FindCommentByIdWithLikes(int? id)
        {
            Comment? find = _context.Comments.Include(p => p.Likes).Where(p => p.Id == id).FirstOrDefault();
            return id is null ? null : find;
        }

        public ICollection<Photo> FindAll()
        {
            return _context.Photos.Include(p => p.Likes).Include(p => p.Comments).ToList();
        }

        public ICollection<Comment> FindAllComments(int? id)
        {
            return _context.Comments.Include(p => p.Likes).Where(p => p.PhotoId == id).ToList();
        }

        public ICollection<Photo> FindStatistics()
        {
            return _context.Photos.OrderByDescending(p => p.Likes.Count()).Include(p => p.Likes).Include(p => p.Comments).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public int AddCommentToPost(Comment comment, int id) // id odnosi się do posta
        {
            Photo? find = _context.Photos.Include(p=>p.Comments).Where(p=>p.Id == id).FirstOrDefault();
            if (find is null) return -1;

            //comment.Post = find;
            //_context.Comments.Add(comment);
            //_context.SaveChanges();

            find.Comments.Add(comment);
            _context.Photos.Update(find);

            _context.SaveChanges();

            return comment.Id;
        }

        public int AddLikeToPost(Like like, int id)
        {
            Photo? find = _context.Photos.Include(p => p.Likes).Where(p => p.Id == id).FirstOrDefault();
            if (find is null) return -1;

            find.Likes.Add(like);

            _context.Photos.Update(find);
            _context.SaveChanges();

            return like.Id;
        }

        public int AddLikeToComment(LikeForComment like, int id)
        {
            Comment? find = _context.Comments.Include(p => p.Likes).Where(p => p.Id == id).FirstOrDefault();
            if (find is null) return -1;

            find.Likes.Add(like);

            _context.Comments.Update(find);
            _context.SaveChanges();

            return like.Id;
        }

        public int DeleteLikeFromPost(Like like, int id)
        {
            Photo? find = _context.Photos.Include(p => p.Likes).Where(p => p.Id == id).FirstOrDefault();
            if (find is null) return -1;

            find.Likes.Remove(like);
            _context.Likes.Remove(like);

            _context.Photos.Update(find);
            _context.SaveChanges();

            return like.Id;
        }

        public int DeleteLikeFromComment(LikeForComment like, int id)
        {
            Comment? find = _context.Comments.Include(p => p.Likes).Where(p => p.Id == id).FirstOrDefault();
            if (find is null) return -1;

            find.Likes.Remove(like);
            _context.LikesForComment.Remove(like);

            _context.Comments.Update(find);
            _context.SaveChanges();

            return like.Id;
        }

        public PagingList<Photo> FindPage(int page = 1, int size = 3)
        {
            if (page > 5000) page = 5000;
            if (size > 100) size = 100;
            int totalCount = _context.Photos.Count();
            List<Photo?> posts = _context.Photos.OrderBy(p => p.Data).Skip((page - 1) * size).Take(size).Include(p => p.Likes).Include(p => p.Comments).ToList();
            return PagingList<Photo>.Create(posts, totalCount, page, size);
        }
    }
}
