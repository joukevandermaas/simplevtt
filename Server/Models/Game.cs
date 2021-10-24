
namespace SimpleVtt.Server.Models;

public class Game
{
    public List<View> Views { get; init; } = new();

    public string Name { get; set; } = string.Empty;
    public Guid Id { get; init; } = new();
}
