using JordansPizza.Models;
using JordansPizza.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace JordansPizza.Repositories
{
    public class PizzaRepository : IMongoRepository<Pizza>
    {
        private readonly IMongoClient _mongoClient;

        public PizzaRepository(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<Pizza> Create(Pizza data)
        {
            data.CreatedAt = DateTime.UtcNow;
            data.UpdatedAt = DateTime.UtcNow;
            await GetCollection().InsertOneAsync(data);
            var pizzaList = await GetCollection().AsQueryable().ToListAsync();
            return pizzaList.FirstOrDefault(x => x.Id == data.Id);
        }

        public Task Delete(string id, bool hardDelete = false)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pizza>> GetAll()
        {
            List<Pizza> pizzaCollection = await GetCollection().AsQueryable()
                .Where(u => !u.Deleted).ToListAsync();
            return pizzaCollection;
        }

        public Task<Pizza> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> Update(string id, Pizza data)
        {
            throw new NotImplementedException();
        }

        private IMongoCollection<Pizza> GetCollection()
        {
            IMongoDatabase database = _mongoClient.GetDatabase("pizzaorderingapi");
            IMongoCollection<Pizza> collection = database.GetCollection<Pizza>("pizzas");
            return collection;
        }
    }
}
