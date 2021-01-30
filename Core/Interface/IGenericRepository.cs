using Core.DbModels;
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
    }
}
