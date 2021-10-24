
namespace SimpleVtt.Server.Models;

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
