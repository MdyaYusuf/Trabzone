﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Trabzone.Core.Entities;

namespace Trabzone.Core.Repositories;

public class EfBaseRepository<TContext, TEntity, TId> : IRepository<TEntity, TId>
  where TEntity : Entity<TId>, new()
  where TContext : DbContext
{
  protected TContext _context { get; }
  public EfBaseRepository(TContext context)
  {
    _context = context;
  }

  public async Task<TEntity> AddAsync(TEntity entity)
  {
    entity.CreatedDate = DateTime.UtcNow;
    await _context.Set<TEntity>().AddAsync(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<TEntity?> DeleteAsync(TEntity entity)
  {
    _context.Set<TEntity>().Remove(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<List<TEntity>> GetAllAsync(bool enableTracking = false, bool withDeleted = false, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, CancellationToken cancellationToken = default)
  {
    IQueryable<TEntity> query = _context.Set<TEntity>();

    if (!enableTracking)
    {
      query = query.AsNoTracking();
    }

    if (withDeleted)
    {
      query = query.IgnoreQueryFilters();
    }

    if (filter != null)
    {
      query = query.Where(filter);
    }

    if (orderBy != null)
    {
      query = orderBy(query);
    }

    return await query.ToListAsync(cancellationToken);
  }

  public async Task<TEntity?> GetByIdAsync(TId id)
  {
    return await _context.Set<TEntity>().FindAsync(id);
  }

  public async Task<TEntity?> UpdateAsync(TEntity entity)
  {
    entity.UpdatedDate = DateTime.UtcNow;
    _context.Set<TEntity>().Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}