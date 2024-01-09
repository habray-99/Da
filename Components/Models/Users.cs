namespace Draft.Components.Models;

public class Users
{
    public Guid? Guid { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool IsAdmin { get; set; }
}

public class AllUser
{
    public List<Users> UsersList { get; init; } = new();
}