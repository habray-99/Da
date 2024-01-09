namespace Draft.Components.Models;

public class CoffeeAddOns
{
    public Guid Guid { get; set; }
    public string? AddOnName { get; set; }
    public double AddOnPrice { set; get; }
}

internal class AllListOfCoffeeAddOns
{
    public List<CoffeeAddOns> AddOnsList { get; init; } = [];
}