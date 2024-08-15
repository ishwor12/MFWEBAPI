using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthRepo.Abstraction
{
    public interface IAuthGenericRepo<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Insert(T model);
        Task InsertRangeAsync(IEnumerable<T> model);
        void Update(T model);
        void UpdateRange(IEnumerable<T> model);
        void Delete(int id);
        void Delete(T deleteEntity);
        void DeleteRange(IEnumerable<T> model);
        void Save();
        Task SaveAsync();
        string GetConnectionString();
    }
}
