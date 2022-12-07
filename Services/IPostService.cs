using aplikacja_zdjecia_z_wakacji.Models;

namespace aplikacja_zdjecia_z_wakacji.Services
{
    public interface IPostService
    {
        public int Save(Post book);

        public bool Delete(int? id);

        public Post? FindBy(int? id);

        public ICollection<Post> FindAll();
    }
}
