
namespace SimpleVtt.Server.Models;

public record ElementUpdate(Guid ElementId, Guid Parent, Guid Source)
{
    public string? Name { get; init; }

    public int? X { get; init; }
    public int? Y { get; init; }

    public Visibility? Visibility { get; init; }

    public List<Guid>? Children { get; init; }
    public List<string>? Statuses { get; init; }
}
