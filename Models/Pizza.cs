using JordansPizza.Models.Requests;

namespace JordansPizza.Models
{
    public class Pizza : BaseResource
    {
        public List<string> Toppings { get; set; } = new List<string>();

        public Pizza() { }
        public Pizza(PizzaCreateRequest request)
        {
            Id = Guid.NewGuid().ToString();
            Toppings = request.Toppings;
        }
    }
}
