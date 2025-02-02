﻿using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Catalog.Host.Services
{
    public class DbContextWrapper<T> : Infrastructure.Services.Interfaces.IDbContextWrapper<T>
     where T : DbContext
    {
        private readonly T _dbContext;

        public DbContextWrapper(
            IDbContextFactory<T> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public T DbContext => _dbContext;

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
