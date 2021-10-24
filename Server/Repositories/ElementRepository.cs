
using SimpleVtt.Server.Models;

namespace SimpleVtt.Server.Repositories;

public class ElementRepository
{
    // todo make thread safe
    private readonly Dictionary<Guid, Element> _elements = new();

    public void ProcessUpdate(ElementUpdate update)
    {
        // todo handle simultaneous updates of same element

        var elem = _elements[update.ElementId];

        elem.Name = update.Name ?? elem.Name;
        elem.X = update.X ?? elem.X;
        elem.Y = update.Y ?? elem.Y;
        elem.Visibility = update.Visibility ?? elem.Visibility;

        elem.Children = update.Children ?? elem.Children;
        elem.Statuses = update.Statuses ?? elem.Statuses;
    }

    public Element Get(Guid id)
    {
        return _elements[id];
    }

    public void Remove(Guid id)
    {
        _elements.Remove(id);
    }

    public void Add(Element element)
    {
        _elements.Add(element.Id, element);
    }
}
