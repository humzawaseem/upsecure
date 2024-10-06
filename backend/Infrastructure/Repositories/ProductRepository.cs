using MongoDB.Driver;
using secureapis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
 
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task CreateAsync(Product item);
        Task UpdateAsync(string id, Product updatedItem);
        Task DeleteAsync(string id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductRepository(IMongoDatabase database)
        {
            _productCollection = database.GetCollection<Product>("Products");
        }

        public async Task<List<Product>> GetAllAsync() =>
            await _productCollection.Find(_ => true).ToListAsync();

        public async Task<Product> GetByIdAsync(string id) =>
            await _productCollection.Find(item => item.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product item) {
             await _productCollection.InsertOneAsync(item);

        }

        public async Task UpdateAsync(string id, Product updatedItem) =>
            await _productCollection.ReplaceOneAsync(item => item.Id == id, updatedItem);

        public async Task DeleteAsync(string id) =>
            await _productCollection.DeleteOneAsync(item => item.Id == id);
    }
}
