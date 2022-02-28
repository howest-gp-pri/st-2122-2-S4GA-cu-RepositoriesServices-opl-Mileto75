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
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<Genre> _genres;

        public GenreRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _genres = _applicationDbContext.Genres;
        }
        public async Task AddGenreAsync(Genre toAdd)
        {
            _genres.Add(toAdd);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(Genre toDelete)
        {
            _genres.Remove(toDelete);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _genres.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _genres.ToListAsync();
        }

        public async Task<IEnumerable<Genre>> SearchGenresByTitleAsync(string needle)
        {
            return await _genres.Where(g => g.Name.ToUpper().Contains(needle.ToUpper())).ToListAsync();
        }

        public async Task UpdateGenreAsync(Genre toUpdate)
        {
            _genres.Update(toUpdate);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
