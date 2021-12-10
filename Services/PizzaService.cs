using JordansPizza.Models;
using JordansPizza.Models.Requests;
using JordansPizza.Repositories.Interfaces;

namespace JordansPizza.Services
{
    public class PizzaService
    {
        private readonly IMongoRepository<Pizza> _pizzaRepository;

        public PizzaService(IMongoRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository; 
        }

        public async Task<List<Pizza>> GetAll()
        {
            return await _pizzaRepository.GetAll();
        }

        public async Task<Pizza> CreatePizza(PizzaCreateRequest request)
        {
            Pizza pizza = new Pizza(request);
            return await _pizzaRepository.Create(pizza);
        }
    }
}
