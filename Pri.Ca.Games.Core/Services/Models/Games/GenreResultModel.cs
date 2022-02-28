using Pri.Ca.Games.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Core.Services.Models.Games
{
    public class GenreResultModel : BaseResultModel
    {
        public IEnumerable<Genre> Genres { get; set; }
    }
}
