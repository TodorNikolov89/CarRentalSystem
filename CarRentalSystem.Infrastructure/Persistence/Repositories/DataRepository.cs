﻿namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Domain.Common;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {

        private readonly CarRentalDbContext db;

        protected DataRepository(CarRentalDbContext db) => this.db = db;

        protected IQueryable<TEntity> All() => this.db.Set<TEntity>();
    }
}
