using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImporterUI.Data
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveAsync();
        bool HasChanges();
        void Add(T model);
        void Remove(T model);
    }
}