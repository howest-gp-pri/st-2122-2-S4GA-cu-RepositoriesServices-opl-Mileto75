using Pri.Ca.Games.Core.Entities;
using Pri.Ca.Games.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Infrastructure.Repositories
{
    public class GenericGenreRepository : BaseRepository<Genre>
    {
        public GenericGenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
