using JordansPizza.Models;
using JordansPizza.Models.Requests;
using JordansPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JordansPizza.Controllers
{
    [ApiController]
    [Route("pizzas")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<Pizza>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _pizzaService.GetAll());
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, null, typeof(Pizza))]
        public async Task<IActionResult> Create(PizzaCreateRequest request)
        {
            var resource = await _pizzaService.CreatePizza(request);
            return Created($"/pizzas/{resource.Id}", resource);
        }
    }
}
