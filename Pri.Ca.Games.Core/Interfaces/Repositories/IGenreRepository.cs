using Pri.Ca.Games.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Core.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        //talks to the Genre database table
        //define cruds
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task AddGenreAsync(Genre toAdd);
        Task UpdateGenreAsync(Genre toUpdate);
        Task DeleteGenreAsync(Genre toDelete);
        Task<IEnumerable<Genre>> SearchGenresByTitleAsync(string needle);
    }
}
