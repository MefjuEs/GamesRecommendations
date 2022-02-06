using System.Collections.Generic;

namespace MAG.AppServices
{
    public class PlatformListWithFiltersDTO : BaseReturnedListWithFilters
    {
        public List<PlatformInListDTO> PlatformList { get; set; }
    }
}
