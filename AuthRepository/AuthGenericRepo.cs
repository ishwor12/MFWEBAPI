using AuthRepo.Abstraction;
using Domain;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthRepository
{
    public class AuthGenericRepo<T> : IAuthGenericRepo<T> where T : class
    {
        protected readonly UserDbContext _userContext;
        protected readonly ApplicationContext _applicationContext;
        protected readonly UserManager<ApplicationUser> _userManager;


        private readonly DbSet<T> _dbSet;
        public AuthGenericRepo(UserDbContext context,UserManager<ApplicationUser> userManager)
        {
            _userContext = context;
            _dbSet = _userContext.Set<T>();
            _userManager = userManager;
        }
        public AuthGenericRepo(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _applicationContext = context;
            _dbSet = _applicationContext.Set<T>();
            _userManager = userManager;
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Insert(T model)
        {
            _dbSet.Add(model);
        }
        public async Task InsertRangeAsync(IEnumerable<T> model)
        {
            await _dbSet.AddRangeAsync(model);
        }
        public void Update(T model)
        {
            _dbSet.Update(model);
        }

        public void UpdateRange(IEnumerable<T> model)
        {
            _dbSet.UpdateRange(model);
        }
        public void Delete(int id)
        {
            var existing = _dbSet.Find(id);
            _dbSet.Remove(existing);
        }
        public void Delete(T deleteEntity)
        {
            _dbSet.Remove(deleteEntity);
        }
        public void DeleteRange(IEnumerable<T> model)
        {
            _dbSet.RemoveRange(model);
        }
        public void Save()
        {
            _userContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _userContext.SaveChangesAsync();
        }
        public string GetConnectionString()
        {
            return _userContext.Database.GetDbConnection().ConnectionString;
        }

    }
}
