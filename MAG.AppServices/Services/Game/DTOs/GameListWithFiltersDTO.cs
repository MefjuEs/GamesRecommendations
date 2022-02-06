using System.Collections.Generic;

namespace MAG.AppServices
{
    public class GameListWithFiltersDTO : BaseReturnedListWithFilters
    {
        public List<GameInListDTO> GameList { get; set; }
    }
}
