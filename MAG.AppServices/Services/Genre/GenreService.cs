using MAG.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public class GenreService : IGenreService
    {
        private readonly GameDbContext dbContext;

        public GenreService(GameDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> InsertGenre(GenreDTO genreDTO)
        {
            if (string.IsNullOrWhiteSpace(genreDTO.Name) ||
                dbContext.Genres.Any(g => g.Name.ToLower().Equals(genreDTO.Name.ToLower())))
                return false;

            var newGenre = new Genre()
            {
                Name = genreDTO.Name,
                Icon = genreDTO.Icon
            };

            dbContext.Genres.Add(newGenre);
            dbContext.SaveChanges();

            return true;
        }

        public async Task<Genre> GetGenre(long id)
        {
            return dbContext.Genres.Find(id);
        }

        public List<GenreInListDTO> GetGenres()
        {
            return dbContext.Genres.Select(g => new GenreInListDTO()
            {
                Id = g.Id,
                Name = g.Name,
                Icon = g.Icon,
            }).ToList();
        }

        public async Task<GenreListWithFiltersDTO> GetGenresByName(GenreFiltersDTO genreFilter)
        {
            if (string.IsNullOrWhiteSpace(genreFilter.Name))
            {
                genreFilter.Name = "";
            }

            if (string.IsNullOrWhiteSpace(genreFilter.OrderBy))
            {
                genreFilter.OrderBy = "";
            }

            var pageSize = genreFilter.PageSize.HasValue ? genreFilter.PageSize.Value : int.MaxValue;

            var allElements = dbContext.Genres.Count(g => g.Name.ToLower().Contains(genreFilter.Name.ToLower()));

            var result = new GenreListWithFiltersDTO()
            {
                CurrentPage = genreFilter.Page,
                PageSize = pageSize,
                AllPages = (int)Math.Ceiling(allElements * 1.0 / pageSize),
                AllElements = allElements
            };

            var genres = dbContext.Genres.Where(g => g.Name.ToLower().Contains(genreFilter.Name.ToLower()));

            switch (genreFilter.OrderBy.ToLower())
            {
                case "namedesc":
                    genres = genres.OrderByDescending(g => g.Name);
                    break;
                case "nameasc":
                    genres = genres.OrderBy(g => g.Name);
                    break;
                default:
                    break;
            }

            genres = genres.Skip((genreFilter.Page - 1) * pageSize).Take(pageSize);

            result.GenreList = genres.Select(g => new GenreInListDTO()
            {
                Id = g.Id,
                Name = g.Name,
                Icon = g.Icon
            }).ToList();

            return result;
        }

        public async Task<bool> UpdateGenre(GenreDTO genreDTO)
        {
            if (string.IsNullOrWhiteSpace(genreDTO.Name) ||
                dbContext.Genres.Any(g => g.Name.ToLower().Equals(genreDTO.Name.ToLower()) && g.Id != genreDTO.Id))
                return false;

            var genre = dbContext.Genres.Find(genreDTO.Id);

            if (genre == null)
                return false;

            genre.Name = genreDTO.Name;
            genre.Icon = genreDTO.Icon;

            dbContext.Genres.Update(genre);
            dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteGenre(long id)
        {
            var genre = dbContext.Genres.Find(id);

            if (genre != null)
            {
                dbContext.Genres.Remove(genre);
                dbContext.SaveChanges();
            }

            return true;
        }

        public async Task<bool> IsGenreInDb(long id)
        {
            return await dbContext.Genres.AnyAsync(g => g.Id == id);
        }
    }
}
