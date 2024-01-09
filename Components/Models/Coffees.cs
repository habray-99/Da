namespace Draft.Components.Models;

public class Coffees
{
    public Guid Guid { get; set; }
    public string? CoffeeName { get; set; }
    public double Price { get; set; }
    // public int Quantity { get; set; }
    
}

internal class AllCoffees
{
    public List<Coffees> CoffeesList { get; init; } = [];
}