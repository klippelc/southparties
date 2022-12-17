﻿using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IDbService
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}