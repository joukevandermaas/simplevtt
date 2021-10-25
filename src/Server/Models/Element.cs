
namespace SimpleVtt.Server.Models;

public class Element : Entity<Element>
{
    public string Name { get; set; } = string.Empty;

    public int X { get; set; }
    public int Y { get; set; }

    public Visibility Visibility { get; set; } = Visibility.Visible;

    public ElementFlags Flags { get; init; }

    // only available based on flags, check first before using
    public string? ImageRef { get; init; }
    public List<Guid>? Children { get; set; } = null;
    public List<string>? Statuses { get; set; } = null;

    public Element Duplicate()
    {
        return new()
        {
            Name = Name,
            Id = Id,
            X = X,
            Y = Y,
            Flags = Flags,
            ImageRef = ImageRef,
            Children = Children?.Select(e => e).ToList(),
            Statuses = Statuses?.Select(s => s).ToList(),
        };
    }
}
