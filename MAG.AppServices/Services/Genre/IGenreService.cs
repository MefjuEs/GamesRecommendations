using MAG.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public interface IGenreService
    {
        Task<bool> InsertGenre(GenreDTO genre);
        Task<Genre> GetGenre(long id);
        List<GenreInListDTO> GetGenres();
        Task<GenreListWithFiltersDTO> GetGenresByName(GenreFiltersDTO genresFilters);
        Task<bool> UpdateGenre(GenreDTO genre);
        Task<bool> DeleteGenre(long id);
        Task<bool> IsGenreInDb(long id);
    }
}
