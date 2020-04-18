using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace borsvarlden.Extensions.Db
{
    public static class DbSetExtensions
    {
        public static EntityEntry<T> AddIfNotExists<T>(this DbSet<T> dbSet, T entity) where T : class, new()
        {
            var exists =  dbSet.Any();
            return !exists ? dbSet.Add(entity) : null;
        }
    }
}
