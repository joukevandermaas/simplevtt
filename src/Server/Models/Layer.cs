
namespace SimpleVtt.Server.Models;

public class Layer : Entity<Layer>
{
    public List<Guid> Elements { get; init; } = new();
    public string Name { get; set; } = string.Empty;
}
