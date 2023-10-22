using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManager.BuildingBlocks.Interfaces;

namespace OrderManager.Infrastructure.Repositories;

public class GenericRepository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier> where TEntity : class
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification)
    {
        return await _context.Set<TEntity>().Where(specification.ToExpression()).ToListAsync();
    }

    public virtual async Task<TEntity?> FindOneAsync(ISpecification<TEntity> specification)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(specification.ToExpression());
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public Task UpdateAsync(TEntity entity)
    {
        return Task.CompletedTask;
    }

    public Task RemoveAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
}