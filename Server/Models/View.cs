
namespace SimpleVtt.Server.Models;


public class View
{
    public List<Layer> Layers { get; init; } = new();
    public string Name { get; set; } = string.Empty;
    public Guid Id { get; init; } = new();

    public static View GetEmpty()
    {
        return new()
        {
            Name = "View",
            Layers = { new() { Name = "Background", } }
        };
    }

    public View Duplicate()
    {
        return new()
        {
            Layers = Layers.Select(l => new Layer()
            {
                Name = l.Name,
                Elements = l.Elements.Select(e => e.Duplicate()).ToList(),
            }).ToList(),
        };
    }
}

public class Layer
{
    public List<Element> Elements { get; init; } = new();
    public string Name { get; set; } = string.Empty;
    public Guid Id { get; init; } = new();

    public void SetVisibility(Visibility visibility)
    {
        foreach (var elem in Elements)
        {
            elem.Visibility = visibility;
        }
    }
}

public class Element
{
    public string Name { get; set; } = string.Empty;
    public Guid Id { get; init; } = new();

    public int X { get; set; }
    public int Y { get; set; }

    public Visibility Visibility { get; set; } = Visibility.Visible;

    public ElementFlags Flags { get; init; }

    // only available based on flags, check first before using
    public string? ImageRef { get; init; }
    public List<Element>? Children { get; init; } = null;
    public List<string>? Statuses { get; init; } = null;

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
            Children = Children?.Select(e => e.Duplicate()).ToList(),
            Statuses = Statuses?.Select(s => s).ToList(),
        };
    }
}

[Flags]
public enum Visibility
{
    Invisible = 0,
    VisibleToGm = 1,
    VisibleToPlayers = 2,

    Visible = ~Invisible,
}

[Flags]
public enum ElementFlags
{
    None = 0,
    IsGroup = 1,
    IsImage = 2,
    SupportsStatus = 4,

    Background = IsImage,
    Token = IsImage | SupportsStatus,
}
