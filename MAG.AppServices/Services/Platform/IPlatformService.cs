using MAG.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public interface IPlatformService
    {
        Task<bool> InsertPlatform(PlatformDTO platform);
        Task<Platform> GetPlatform(long id);
        List<PlatformInListDTO> GetPlatforms();
        Task<PlatformListWithFiltersDTO> GetPlatformsByName(PlatformFiltersDTO platformFilters);
        Task<bool> UpdatePlatform(PlatformDTO platform);
        Task<bool> DeletePlatform(long id);
        Task<bool> IsPlatformInDb(long id);
    }
}
