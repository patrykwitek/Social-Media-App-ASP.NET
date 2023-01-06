using aplikacja_zdjecia_z_wakacji.Models;

namespace aplikacja_zdjecia_z_wakacji.Services
{
    public interface IPostService
    {
        public int Save(Post post);

        public bool Delete(int? id);

        public bool Update(Post post);

        public Post? FindBy(int? id);

        public ICollection<Post> FindAll();

        public ICollection<Post> FindStatistics();

        public int AddCommentToPost(Comment comment, int id);

        public void SaveChanges();

        public Post? FindByIdWithComments(int? id);

        public Post? FindByIdWithLikes(int? id);

        public int AddLikeToPost(Like like, int id);

        public int DeleteLikeFromPost(Like like, int id);

        public PagingList<Post> FindPage(int page, int size);
    }
}
