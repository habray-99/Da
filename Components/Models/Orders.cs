namespace Draft.Components.Models;

public class Order
{
    public Guid Id { get; set; }
    public string CustomerPhone { get; set; }
    public double TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItem> OrderedItems { get; set; }
}

public class OrderItem
{
    public Guid CoffeeGuid { get; set; }
    public List<Guid> AddIns { get; set; } = new List<Guid>();
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}

public class AllOrders
{
    public List<Order> OrdersList { get; set; } = new List<Order>();
}
