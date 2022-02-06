using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public interface IGameService
    {
        Task<bool> InsertGame(InsertUpdateGameDTO gameDTO);
        Task<bool> UpdateGame(InsertUpdateGameDTO gameDTO);
        Task<bool> DeleteGame(long id);
        Task<GameDTO> GetGame(long id);
        Task<List<GenreInGameDTO>> GetGameGenres(long gameId);
        Task<List<PlatformInGameDTO>> GetGamePlatforms(long gameId);
        Task<GameListWithFiltersDTO> GetGameWithFilters(GameFiltersDTO filters);
        List<GameInSelectDTO> GetGamesToSelect(SelectUserFiltersDTO filters);
        Task<bool> DoesGameExist(long gameId);
        Task<bool> UpdateGameRating(long gameId, double avgRating);
        Task<FileDTO> GetGameImage(long gameId);
    }
}
