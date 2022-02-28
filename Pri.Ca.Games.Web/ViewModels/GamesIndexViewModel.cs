using System.Collections.Generic;

namespace Pri.Ca.Games.Web.ViewModels
{
    public class GamesIndexViewModel : BaseViewModel
    {
        public IEnumerable<BaseGameViewModel> Games { get; set; }
    }

    
}
