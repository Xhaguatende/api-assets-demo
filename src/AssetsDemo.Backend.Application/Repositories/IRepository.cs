// -------------------------------------------------------------------------------------
//  <copyright file="IRepository.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Repositories;

using System.Linq.Expressions;

public interface IRepository<T, in TKey>
{
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

    Task<List<T>> GetAllAsync(
        Expression<Func<T, object>>[]? includes = null,
        CancellationToken cancellationToken = default);

    Task<T?> GetByIdAsync(
        TKey id,
        Expression<Func<T, object>>[]? includes = null,
        CancellationToken cancellationToken = default);

    Task<List<T>> GetManyByExpression(
        Expression<Func<T, bool>> expression,
        Expression<Func<T, object>>[]? includes = null,
        CancellationToken cancellationToken = default);

    Task<T?> GetOneByExpression(
        Expression<Func<T, bool>> expression,
        Expression<Func<T, object>>[]? includes = null,
        CancellationToken cancellationToken = default);

    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
}