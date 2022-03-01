using Microsoft.EntityFrameworkCore;
using Pri.Ca.Games.Core.Entities;
using Pri.Ca.Games.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Infrastructure.Repositories
{
    public class GenericGameRepository : BaseRepository<Game>
    {
        public GenericGameRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _table.Include(t => t.Genres)
                .ToListAsync();
        }

        public override async Task<Game> GetByIdAsync(int id)
        {
            return await _table
                .Include(t => t.Genres)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
        //extra methods
        //search
        public async Task<IEnumerable<Game>> Search(string needle)
        {
            return await _table.Include(t => t.Genres)
                .Where(t => t.Name.ToUpper().Contains(needle.ToUpper())).ToListAsync();
        }
    }
}
