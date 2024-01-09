namespace Draft.Components.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid CoffeeId { get; set; }
    public int Quantity { get; set; }
    public List<Guid> AddOnIds { get; set; } = new List<Guid>();
    public string CustomerPhone { get; set; }
    public double TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class AllOrders
{
    public List<Order> OrdersList { get; set; } = new List<Order>();
}
