
namespace SimpleVtt.Server.Models;

public class View : Entity<View>
{
    public List<Layer> Layers { get; init; } = new();
    public string Name { get; set; } = string.Empty;

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
