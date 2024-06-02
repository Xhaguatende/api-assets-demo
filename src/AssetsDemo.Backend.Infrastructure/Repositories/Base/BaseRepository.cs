// -------------------------------------------------------------------------------------
//  <copyright file="BaseRepository.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Infrastructure.Repositories.Base;

using System.Linq.Expressions;
using Application.Repositories;
using Database;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

public abstract class BaseRepository<T, TKey> : IRepository<T, TKey> where T : Entity<TKey> where TKey : notnull
{
    private readonly AssetsContext _context;

    protected BaseRepository(AssetsContext context)
    {
        _context = context;
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        var date = DateTime.UtcNow;
        entity.CreatedAt = date;
        entity.UpdatedAt = date;

        var entry = await _context.Set<T>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entry.Entity;
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(
        Expression<Func<T, object>>[]? includes = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(
        TKey id,
        Expression<Func<T, object>>[]? includes = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }

    public async Task<List<T>> GetManyByExpression(
        Expression<Func<T, bool>> expression,
        Expression<Func<T, object>>[]? includes = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Set<T>().Where(expression);

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<T?> GetOneByExpression(
        Expression<Func<T, bool>> expression,
        Expression<Func<T, object>>[]? includes = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Set<T>().Where(expression);

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        var date = DateTime.UtcNow;
        entity.UpdatedAt = date;

        var entry = _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entry.Entity;
    }
}