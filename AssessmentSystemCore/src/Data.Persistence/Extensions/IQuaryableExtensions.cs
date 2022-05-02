using AssessmentSystemCore.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Data.Persistence.Extensions
{
    public static class IQuaryableExtensions
    {
        public static IQueryable<TEntity> JoinByExpression<TEntity>(this IQueryable<TEntity> queryable, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            foreach (var include in includes)
            {
                queryable.Include(include);
            }

            return queryable;
        }

        public static IQueryable<TEntity> JoinByString<TEntity>(this IQueryable<TEntity> queryable, params string[] includes) where TEntity : Entity
        {
            foreach (var include in includes)
            {
                queryable.Include(include);
            }

            return queryable;
        }
    }
}
