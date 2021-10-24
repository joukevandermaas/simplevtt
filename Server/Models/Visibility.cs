
namespace SimpleVtt.Server.Models;

[Flags]
public enum Visibility
{
    Invisible = 0,
    VisibleToGm = 1,
    VisibleToPlayers = 2,

    Visible = ~Invisible,
}
