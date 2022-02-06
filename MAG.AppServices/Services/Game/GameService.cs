using MAG.AppCommons;
using MAG.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public class GameService : IGameService
    {
        private readonly GameDbContext dbContext;
        private readonly IGenreService genreService;
        private readonly IPlatformService platformService;
        private readonly IFileService fileService;
        private readonly IUserService userService;

        public GameService(GameDbContext dbContext, IGenreService genreService, IPlatformService platformService, IFileService fileService, IUserService userService)
        {
            this.dbContext = dbContext;
            this.genreService = genreService;
            this.platformService = platformService;
            this.fileService = fileService;
            this.userService = userService;
        }

        #region Games
        public async Task<bool> InsertGame(InsertUpdateGameDTO gameDTO)
        {
            if (string.IsNullOrWhiteSpace(gameDTO.Title))
                return false;

            if (dbContext.Games.Any(m => m.Title.ToLower().Equals(gameDTO.Title.ToLower())))
                return false;

            if (gameDTO.Description.Length > StaticValues.GameDescriptionMaxLength)
                return false;

            var game = new Game()
            {
                Title = gameDTO.Title,
                Description = gameDTO.Description,
                ReleaseYear = gameDTO.ReleaseYear,
                Publisher = gameDTO.Publisher,
                Producer = gameDTO.Producer,
                AverageRating = 0.0,
                NumberOfVotes = 0,
                Image = ""
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            var gameId = dbContext.Games.FirstOrDefault(m => m.Title.Equals(gameDTO.Title)).Id;

            await InsertGameGenres(gameId, gameDTO.Genres);
            await InsertGamePlatforms(gameId, gameDTO.Platforms);
            game.Image = await fileService.InsertGameImage(gameId, gameDTO.File);

            dbContext.Games.Update(game);
            dbContext.SaveChanges();

            return true;
        }
        public async Task<bool> UpdateGame(InsertUpdateGameDTO gameDTO)
        {
            if (string.IsNullOrWhiteSpace(gameDTO.Title))
                return false;

            if (dbContext.Games.Any(m => m.Title.ToLower().Equals(gameDTO.Title.ToLower()) && m.Id != gameDTO.Id))
                return false;

            if (gameDTO.Description.Length > StaticValues.GameDescriptionMaxLength)
                return false;

            var game = dbContext.Games.Find(gameDTO.Id);

            if (game == null)
                return false;

            game.Title = gameDTO.Title;
            game.Description = gameDTO.Description;
            game.ReleaseYear = gameDTO.ReleaseYear;
            game.Publisher = gameDTO.Publisher;
            game.Producer = gameDTO.Producer;

            await UpdateGameGenres(game.Id, gameDTO.Genres);
            await UpdateGamePlatforms(game.Id, gameDTO.Platforms);

            if (gameDTO.UpdateImage)
                game.Image = await fileService.UpdateGameImage(game.Id, game.Image, gameDTO.File);

            dbContext.Games.Update(game);
            dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteGame(long id)
        {
            var game = dbContext.Games.Find(id);

            if (game != null)
            {
                fileService.DeleteGameImage(game.Image);

                dbContext.Games.Remove(game);
                dbContext.SaveChanges();
            }

            return true;
        }
        #endregion

        #region Genres
        private async Task InsertGameGenres(long gameId, List<long> genres)
        {
            if (genres == null)
                return;

            var genreList = new List<GameGenre>();
            genres = genres.Distinct().ToList();

            foreach (var genreId in genres)
            {
                if (await genreService.IsGenreInDb(genreId))
                {
                    genreList.Add(new GameGenre()
                    {
                        GenreId = genreId,
                        GameId = gameId
                    });
                }
            }

            dbContext.GameGenres.AddRange(genreList);
            dbContext.SaveChanges();
        }

        private async Task UpdateGameGenres(long gameId, List<long> genres)
        {
            if (genres == null)
                genres = new List<long>();

            genres = genres.Distinct().ToList();

            var existingGameGenres = dbContext.GameGenres.Where(gg => gg.GameId == gameId).ToList();

            var genreList = new List<GameGenre>();

            foreach (var genreId in genres)
            {
                if (await genreService.IsGenreInDb(genreId))
                {
                    var existingGG = existingGameGenres.Find(gg => gg.GenreId == genreId);
                    if (existingGG != null)
                    {
                        existingGameGenres.Remove(existingGG);
                    }
                    else
                    {
                        genreList.Add(new GameGenre()
                        {
                            GenreId = genreId,
                            GameId = gameId
                        });
                    }
                }
            }

            dbContext.GameGenres.AddRange(genreList);
            dbContext.GameGenres.RemoveRange(existingGameGenres);
            dbContext.SaveChanges();
        }
        #endregion

        #region Platforms
        private async Task InsertGamePlatforms(long gameId, List<long> platforms)
        {
            if (platforms == null)
                return;

            var platformList = new List<GamePlatform>();
            platforms = platforms.Distinct().ToList();

            foreach (var platformId in platforms)
            {
                if (await platformService.IsPlatformInDb(platformId))
                {
                    platformList.Add(new GamePlatform()
                    {
                        PlatformId = platformId,
                        GameId = gameId
                    });
                }
            }

            dbContext.GamePlatforms.AddRange(platformList);
            dbContext.SaveChanges();
        }

        private async Task UpdateGamePlatforms(long gameId, List<long> platforms)
        {
            if (platforms == null)
                platforms = new List<long>();

            platforms = platforms.Distinct().ToList();

            var existingGamePlatforms = dbContext.GamePlatforms.Where(gp => gp.GameId == gameId).ToList();

            var platformList = new List<GamePlatform>();

            foreach (var platformId in platforms)
            {
                if (await platformService.IsPlatformInDb(platformId))
                {
                    var existingGP = existingGamePlatforms.Find(gp => gp.PlatformId == platformId);
                    if (existingGP != null)
                    {
                        existingGamePlatforms.Remove(existingGP);
                    }
                    else
                    {
                        platformList.Add(new GamePlatform()
                        {
                            PlatformId = platformId,
                            GameId = gameId
                        });
                    }
                }
            }

            dbContext.GamePlatforms.AddRange(platformList);
            dbContext.GamePlatforms.RemoveRange(existingGamePlatforms);
            dbContext.SaveChanges();
        }
        #endregion

        #region Getters
        public async Task<GameDTO> GetGame(long id)
        {
            var game = await dbContext.Games.FindAsync(id);

            if (game == null)
                return null;

            var gameImage = fileService.GetGameImage(game.Image);
            var gameGenres = await GetGameGenres(id);
            var gamePlatforms = await GetGamePlatforms(id);

            var gameDTO = new GameDTO()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ReleaseYear = game.ReleaseYear,
                Publisher = game.Publisher,
                Producer = game.Producer,
                AverageRating = game.AverageRating,
                NumberOfVotes = game.NumberOfVotes,
                Image = gameImage,
                Genres = gameGenres,
                Platforms = gamePlatforms
            };

            return gameDTO;
        }

        public async Task<List<GenreInGameDTO>> GetGameGenres(long id)
        {
            return dbContext.GameGenres.Include(gg => gg.Genre)
                .Where(gg => gg.GameId == id)
                .Select(gg => new GenreInGameDTO()
                {
                    GameId = gg.GameId,
                    GenreId = gg.GenreId,
                    Name = gg.Genre.Name,
                    Icon = gg.Genre.Icon
                }).ToList();
        }

        public async Task<List<PlatformInGameDTO>> GetGamePlatforms(long id)
        {
            return dbContext.GamePlatforms.Include(gp => gp.Platform)
                .Where(gp => gp.GameId == id)
                .Select(gp => new PlatformInGameDTO()
                {
                    GameId = gp.GameId,
                    PlatformId = gp.PlatformId,
                    Name = gp.Platform.Name,
                    Icon = gp.Platform.Icon
                }).ToList();
        }

        public async Task<GameListWithFiltersDTO> GetGameWithFilters(GameFiltersDTO filters)
        {
            if (string.IsNullOrWhiteSpace(filters.Title))
            {
                filters.Title = "";
            }

            var pageSize = filters.PageSize.HasValue ? filters.PageSize.Value : int.MaxValue;

            Func<Game, bool> predicate = (m => m.Title.ToLower().Contains(filters.Title.ToLower()) &&
                                (!filters.ReleaseYearFrom.HasValue || m.ReleaseYear >= filters.ReleaseYearFrom.Value) &&
                                (!filters.ReleaseYearTo.HasValue || m.ReleaseYear <= filters.ReleaseYearTo.Value) &&
                                (!filters.AvgRatingFrom.HasValue || m.AverageRating >= filters.AvgRatingFrom) &&
                                (!filters.AvgRatingTo.HasValue || m.AverageRating <= filters.AvgRatingTo) &&
                                (!filters.GenreId.HasValue || m.GameGenres.Any(gg => gg.GenreId == filters.GenreId)) &&
                                (!filters.PlatformId.HasValue || m.GamePlatforms.Any(gp => gp.PlatformId == filters.PlatformId)));

            var allElements = dbContext.Games.Include(g => g.GameGenres).Include(g => g.GamePlatforms).Count(predicate);

            var result = new GameListWithFiltersDTO()
            {
                CurrentPage = filters.Page,
                PageSize = pageSize,
                AllPages = (int)Math.Ceiling(allElements * 1.0 / pageSize),
                AllElements = allElements
            };

            var games = dbContext.Games.Include(g => g.GameGenres).Include(g => g.GamePlatforms)
                .Where(predicate).Select(m => new GameInListDTO()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    ReleaseYear = m.ReleaseYear,
                    AverageRating = m.AverageRating,
                    ImageName = m.Image
                });

            switch (filters.OrderBy?.ToLower())
            {
                case "titledesc":
                    games = games.OrderByDescending(m => m.Title);
                    break;
                case "titleasc":
                    games = games.OrderBy(m => m.Title);
                    break;
                case "releaseyeardesc":
                    games = games.OrderByDescending(m => m.ReleaseYear);
                    break;
                case "releaseyearasc":
                    games = games.OrderBy(m => m.ReleaseYear);
                    break;
                case "averageratingdesc":
                    games = games.OrderByDescending(m => m.AverageRating);
                    break;
                case "averageratingasc":
                    games = games.OrderBy(m => m.AverageRating);
                    break;
                default:
                    break;
            }

            result.GameList = games.Skip((filters.Page - 1) * pageSize).Take(pageSize).ToList();

            foreach (var game in result.GameList)
            {
                game.Image = fileService.GetGameImage(game.ImageName);
                game.Genres = (await GetGameGenres(game.Id)).Select(g => g.Name).ToList();
                game.Platforms = (await GetGamePlatforms(game.Id)).Select(g => g.Name).ToList();
            }

            return result;
        }

        public List<GameInSelectDTO> GetGamesToSelect(SelectUserFiltersDTO filters)
        {
            if (string.IsNullOrWhiteSpace(filters.StartsWith))
            {
                filters.StartsWith = "";
            }

            return dbContext.Games.Where(m => m.Title.StartsWith(filters.StartsWith))
                .OrderBy(m => m.Title)
                .Take(5)
                .Select(m => new GameInSelectDTO()
                {
                    Id = m.Id,
                    Title = m.Title
                }).ToList();
        }
        #endregion

        public async Task<bool> DoesGameExist(long id)
        {
            return (await dbContext.Games.FindAsync(id)) != null;
        }

        public async Task<bool> UpdateGameRating(long gameId, double avgRating)
        {
            var game = await dbContext.Games.FindAsync(gameId);

            game.AverageRating = avgRating;
            game.NumberOfVotes += 1;

            dbContext.Games.Update(game);
            dbContext.SaveChanges();

            return true;
        }

        public async Task<FileDTO> GetGameImage(long gameId)
        {
            var game = await dbContext.Games.FindAsync(gameId);

            if (game == null)
                return null;

            return fileService.GetGameImage(game.Image);
        }
    }
}
