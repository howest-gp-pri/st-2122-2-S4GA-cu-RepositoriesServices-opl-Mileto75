using Pri.Ca.Games.Core.Services.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Core.Interfaces.Services
{
    public interface IGenreService
    {
        Task<GenreResultModel> GetGenresAsync();
        Task<GenreResultModel> GetGenreByIdAsync(int id);
    }
}
