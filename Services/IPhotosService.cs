using aplikacja_zdjecia_z_wakacji.Models;

namespace aplikacja_zdjecia_z_wakacji.Services
{
    public interface IPhotosService
    {
        public int Save(Photo post);

        public bool Delete(int? id);

        public bool Update(Photo photo);

        public bool UpdateByPhotoTemp(Photo? find, PhotoTempForEdit photo);

        public Photo? FindBy(int? id);

        public ICollection<Photo> FindAll();

        public ICollection<Comment> FindAllComments(int? id);

        public ICollection<Photo> FindStatistics();

        public int AddCommentToPost(Comment comment, int id);

        public void SaveChanges();

        public Photo? FindByIdWithComments(int? id);

        public Photo? FindByIdWithLikes(int? id);

        public Comment? FindCommentByIdWithLikes(int? id);

        public Photo? FindByIdWithLikesAndComments(int? id);

        public int AddLikeToPost(Like like, int id);

        public int AddLikeToComment(LikeForComment like, int id);

        public int DeleteLikeFromPost(Like like, int id);

        public int DeleteLikeFromComment(LikeForComment like, int id);

        public PagingList<Photo> FindPage(int page, int size);
    }
}
