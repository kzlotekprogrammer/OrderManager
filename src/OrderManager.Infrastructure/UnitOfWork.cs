﻿using System.Threading.Tasks;
using OrderManager.BuildingBlocks.Interfaces;

namespace OrderManager.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}