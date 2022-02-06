using System.Collections.Generic;

namespace MAG.AppServices
{
    public class GenreListWithFiltersDTO : BaseReturnedListWithFilters
    {
        public List<GenreInListDTO> GenreList { get; set; }
    }
}
