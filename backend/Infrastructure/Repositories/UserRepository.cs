using MongoDB.Driver;
using secureapis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
 
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task CreateAsync(User item);
        Task UpdateAsync(string id, User updatedItem);
        Task DeleteAsync(string id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IMongoDatabase database)
        {
            _userCollection = database.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAllAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User> GetByIdAsync(string id) =>
            await _userCollection.Find(item => item.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User item) =>
            await _userCollection.InsertOneAsync(item);

        public async Task UpdateAsync(string id, User updatedItem) =>
            await _userCollection.ReplaceOneAsync(item => item.Id == id, updatedItem);

        public async Task DeleteAsync(string id) =>
            await _userCollection.DeleteOneAsync(item => item.Id == id);
    }
}
