namespace Draft.Components.Models;

public class Customers
{
    public string? CustomerName { get; set; }
    public string? PhoneNo { get; set; }
}

class AllCustomerList
{
    public List<Customers> AllCustomer { get; init; } = [];
}