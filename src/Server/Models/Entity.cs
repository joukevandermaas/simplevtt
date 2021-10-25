
namespace SimpleVtt.Server.Models;

public abstract class Entity<T> : IEquatable<T> where T : Entity<T>
{
    public Guid Id { get; init; } = new();
    public Guid GameId { get; init; }

    public bool Equals(T? other) => (ReferenceEquals(this, other)) || (other is Entity<T> entity && entity.Id == Id);
    public override int GetHashCode() => Id.GetHashCode();
    public override bool Equals(object? obj) => (obj is Entity<T> entity) && Equals(entity);

    public static bool operator ==(Entity<T> left, Entity<T> right) => left.Equals(right);
    public static bool operator !=(Entity<T> left, Entity<T> right) => !(left == right);
}
