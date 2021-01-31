using Core.DbModels;
using Core.Interface;
using Core.Spacitifition;
using Data.EfContexts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implements
{
    public class GenericRepository<T> : IGenericRepository<T>
         where T : BaseEntity, new()
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetEntityWithSpec(ISpecifition<T> spec)
        {
            return await ApplySpecificiton(spec).FirstOrDefaultAsync();
        }

        public async Task<T> GetIdByAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifition<T> spec)
        {
            return await ApplySpecificiton(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecificiton(ISpecifition<T> spec)
        {
            return SpesificationEvaluter<T>.GetQuery(_context.Set<T>().AsQueryable(), spec); 
        }
    }
}
