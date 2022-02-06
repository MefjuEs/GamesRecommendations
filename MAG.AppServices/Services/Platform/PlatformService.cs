using MAG.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public class PlatformService : IPlatformService
    {
        private readonly GameDbContext dbContext;

        public PlatformService(GameDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> InsertPlatform(PlatformDTO platformDTO)
        {
            if (string.IsNullOrWhiteSpace(platformDTO.Name) ||
                dbContext.Genres.Any(g => g.Name.ToLower().Equals(platformDTO.Name.ToLower())))
                return false;

            var newPlatform = new Platform()
            {
                Name = platformDTO.Name,
                Icon = platformDTO.Icon
            };

            dbContext.Platforms.Add(newPlatform);
            dbContext.SaveChanges();

            return true;
        }

        public async Task<Platform> GetPlatform(long id)
        {
            return dbContext.Platforms.Find(id);
        }

        public List<PlatformInListDTO> GetPlatforms()
        {
            return dbContext.Platforms.Select(g => new PlatformInListDTO()
            {
                Id = g.Id,
                Name = g.Name,
                Icon = g.Icon,
            }).ToList();
        }

        public async Task<PlatformListWithFiltersDTO> GetPlatformsByName(PlatformFiltersDTO platformFilter)
        {
            if (string.IsNullOrWhiteSpace(platformFilter.Name))
            {
                platformFilter.Name = "";
            }

            if (string.IsNullOrWhiteSpace(platformFilter.OrderBy))
            {
                platformFilter.OrderBy = "";
            }

            var pageSize = platformFilter.PageSize.HasValue ? platformFilter.PageSize.Value : int.MaxValue;

            var allElements = dbContext.Platforms.Count(g => g.Name.ToLower().Contains(platformFilter.Name.ToLower()));

            var result = new PlatformListWithFiltersDTO()
            {
                CurrentPage = platformFilter.Page,
                PageSize = pageSize,
                AllPages = (int)Math.Ceiling(allElements * 1.0 / pageSize),
                AllElements = allElements
            };

            var platforms = dbContext.Platforms.Where(g => g.Name.ToLower().Contains(platformFilter.Name.ToLower()));

            switch (platformFilter.OrderBy.ToLower())
            {
                case "namedesc":
                    platforms = platforms.OrderByDescending(g => g.Name);
                    break;
                case "nameasc":
                    platforms = platforms.OrderBy(g => g.Name);
                    break;
                default:
                    break;
            }

            platforms = platforms.Skip((platformFilter.Page - 1) * pageSize).Take(pageSize);

            result.PlatformList = platforms.Select(g => new PlatformInListDTO()
            {
                Id = g.Id,
                Name = g.Name,
                Icon = g.Icon
            }).ToList();

            return result;
        }

        public async Task<bool> UpdatePlatform(PlatformDTO platformDTO)
        {
            if (string.IsNullOrWhiteSpace(platformDTO.Name) ||
                dbContext.Platforms.Any(g => g.Name.ToLower().Equals(platformDTO.Name.ToLower()) && g.Id != platformDTO.Id))
                return false;

            var platform = dbContext.Platforms.Find(platformDTO.Id);

            if (platform == null)
                return false;

            platform.Name = platformDTO.Name;
            platform.Icon = platformDTO.Icon;

            dbContext.Platforms.Update(platform);
            dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeletePlatform(long id)
        {
            var platform = dbContext.Platforms.Find(id);

            if (platform != null)
            {
                dbContext.Platforms.Remove(platform);
                dbContext.SaveChanges();
            }

            return true;
        }

        public async Task<bool> IsPlatformInDb(long id)
        {
            return await dbContext.Platforms.AnyAsync(g => g.Id == id);
        }
    }
}
