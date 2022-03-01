using Microsoft.EntityFrameworkCore;
using Pri.Ca.Games.Core.Entities;
using Pri.Ca.Games.Core.Interfaces.Repositories;
using Pri.Ca.Games.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<T> _table;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _table = _applicationDbContext.Set<T>();
        }

        public async Task AddAsync(T toAdd)
        {
            await _table.AddAsync(toAdd);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T toDelete)
        {
            _table.Remove(toDelete);
            await _applicationDbContext.SaveChangesAsync(); 
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(T toUpdate)
        {
            _table.Update(toUpdate);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
