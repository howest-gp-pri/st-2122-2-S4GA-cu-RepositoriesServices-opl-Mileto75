using System.Collections.Generic;

namespace Pri.Ca.Games.Web.ViewModels
{
    public class GenresIndexViewModel : BaseViewModel
    {
        public IEnumerable<BaseGenreViewModel> Genres { get; set; }
    }
}
