﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Context.Contracts
{
    public interface IDbContext
    {
        Database Database { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}
