using SQLite;
using MyApp.Models;

namespace MyApp.Services
{
    public class PostRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public PostRepository(SQLiteAsyncConnection db)
        {
            _db = db;
            _db.CreateTableAsync<Post>().Wait();
        }

        public Task<int> InsertAllAsync(List<Post> posts)
        {
            return _db.InsertAllAsync(posts, true);
        }

        public Task<List<Post>> GetAllAsync()
        {
            return _db.Table<Post>().ToListAsync();
        }
    }
}
