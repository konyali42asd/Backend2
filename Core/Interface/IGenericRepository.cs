using Core.DbModels;
using Core.Spacitifition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
   public interface IGenericRepository<T> where T:BaseEntity,new() 
    {
        Task<T> GetIdByAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecifition<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecifition<T> spec);
    }
}
