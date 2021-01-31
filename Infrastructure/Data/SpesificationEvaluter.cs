using Core.DbModels;
using Core.Spacitifition;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class SpesificationEvaluter<TEntity>  where TEntity :BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecifition<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Critera!=null)
            {
                query = query.Where(spec.Critera);
            }
            query = spec.InCludes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
