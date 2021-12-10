namespace JordansPizza.Models.Requests
{
    public class PizzaCreateRequest
    {
        public List<string> Toppings { get; set; } = new List<string>();
    }
}
