using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(long id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(long id);
    }
}
