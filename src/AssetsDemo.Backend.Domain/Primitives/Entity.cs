// -------------------------------------------------------------------------------------
//  <copyright file="Entity.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Domain.Primitives;

public abstract class Entity<T> : IEqualityComparer<Entity<T>>
    where T : notnull
{
    protected Entity(T id)
    {
        if (id is null || id.Equals(default(T))) throw new ArgumentNullException(nameof(id));

        Id = id;
    }

    public DateTime CreatedAt { get; set; }
    public T Id { get; set; }
    public DateTime UpdatedAt { get; set; }

    public bool Equals(Entity<T>? left, Entity<T>? right)
    {
        if (left == null || right == null) return false;

        return left.Id.Equals(right.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<T> entity && Id.Equals(entity.Id);
    }

    public int GetHashCode(Entity<T> obj)
    {
        return obj.Id.GetHashCode();
    }

    public override int GetHashCode()
    {
        return GetHashCode(this);
    }
}