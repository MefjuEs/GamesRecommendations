using MAG.AppCommons;
using MAG.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public class CommentService : ICommentService
    {
        private readonly GameDbContext db;
        private readonly IGameService gameService;
        private readonly IUserService userService;
        private readonly IUserContext userContext;

        public CommentService(GameDbContext db, IGameService gameService, IUserService userService, IUserContext userContext)
        {
            this.db = db;
            this.gameService = gameService;
            this.userService = userService;
            this.userContext = userContext;
        }

        public async Task<bool> InsertComment(InsertUpdateCommentDTO commentDTO)
        {
            if (!await userService.DoesUserExist(commentDTO.UserId))
                return false;

            if (!await gameService.DoesGameExist(commentDTO.GameId))
                return false;

            if (commentDTO.Rating < 1 || commentDTO.Rating > 10)
                return false;

            if (commentDTO.Content.Length > commentDTO.CommentContentMaxLength)
                return false;

            var comment = new Comment()
            {
                UserId = commentDTO.UserId,
                GameId = commentDTO.GameId,
                Content = commentDTO.Content,
                Rating = commentDTO.Rating,
                Created = DateTime.Now
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            var avgRating = GetAvgGameRating(commentDTO.GameId);
            await gameService.UpdateGameRating(commentDTO.GameId, avgRating);

            return true;
        }

        public async Task<Comment> GetComment(long userId, long gameId)
        {
            return await db.Comments.FindAsync(userId, gameId);
        }

        public async Task<UserCommentListWithFiltersDTO> GetAllComments(CommentsFiltersDTO commentsFilters)
        {
            if (commentsFilters.OrderBy == null)
            {
                commentsFilters.OrderBy = "";
            }

            var pageSize = commentsFilters.PageSize ?? int.MaxValue;

            Func<Comment, bool> predicate = (r => (!commentsFilters.GameId.HasValue || r.GameId == commentsFilters.GameId) &&
                                                 (!commentsFilters.UserId.HasValue || r.UserId == commentsFilters.UserId));

            var allElements = db.Comments.Count(predicate);

            var result = new UserCommentListWithFiltersDTO()
            {
                CurrentPage = commentsFilters.Page,
                PageSize = pageSize,
                AllPages = (int)Math.Ceiling(allElements * 1.0 / pageSize),
                AllElements = allElements
            };

            var comments = db.Comments.Include(r => r.Game)
                .Where(predicate)
                .Select(r => new UserCommentInListDTO()
                {
                    UserId = r.UserId,
                    GameId = r.GameId,
                    Rating = r.Rating,
                    Content = r.Content,
                    GameTitle = r.Game.Title
                });

            switch (commentsFilters.OrderBy.ToLower())
            {
                case "ratingdesc":
                    comments = comments.OrderByDescending(r => r.Rating);
                    break;
                case "ratingasc":
                    comments = comments.OrderBy(r => r.Rating);
                    break;
                case "moviedesc":
                    comments = comments.OrderByDescending(r => r.GameTitle);
                    break;
                case "movieasc":
                    comments = comments.OrderBy(r => r.GameTitle);
                    break;
                case "userid":
                    comments = comments.OrderBy(r => r.UserId);
                    break;
                default:
                    break;
            }

            comments = comments.Skip((commentsFilters.Page - 1) * pageSize).Take(pageSize);
            result.CommentList = comments.ToList();

            foreach (var comment in result.CommentList)
            {
                comment.Username = await userService.GetUsername(comment.UserId);
            }

            return result;
        }

        public async Task<bool> UpdateComment(InsertUpdateCommentDTO commentDTO)
        {
            var comment = db.Comments.Find(commentDTO.UserId, commentDTO.GameId);
            var canModify = this.CanModifyComment(comment);

            if (comment != null && canModify)
            {
                if (!await userService.DoesUserExist(commentDTO.UserId))
                    return false;

                if (!await gameService.DoesGameExist(commentDTO.GameId))
                    return false;

                if (commentDTO.Rating < 1 || commentDTO.Rating > 10)
                    return false;

                if (commentDTO.Content.Length > commentDTO.CommentContentMaxLength)
                    return false;

                comment.Content = commentDTO.Content;
                comment.Rating = commentDTO.Rating;

                db.Comments.Update(comment);
                db.SaveChanges();

                var avgRating = GetAvgGameRating(commentDTO.GameId);
                await gameService.UpdateGameRating(commentDTO.GameId, avgRating);
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteComment(long userId, long gameId)
        {
            var comment = await db.Comments.FindAsync(userId, gameId);
            var canModify = this.CanModifyComment(comment);
            if (comment != null && canModify)
            {
                db.Comments.Remove(comment);
                db.SaveChanges();

                var avgRating = GetAvgGameRating(gameId);
                await gameService.UpdateGameRating(gameId, avgRating);

                return true;
            }

            return false;
        }

        public bool HasUserAlreadyCommented(long gameId)
        {
            if (userContext.IsAuthenticated)
            {
                var userId = userContext.UserAccountId;

                return db.Comments.Any(r => r.GameId == gameId && r.UserId == userId);
            }
            else
            {
                return false;
            }
        }

        private double GetAvgGameRating(long gameId)
        {
            var comments = db.Comments.Where(m => m.GameId == gameId).ToList();

            if (comments == null || comments.Count == 0)
            {
                return 0.0;
            }

            double sumRating = 0.0;
            foreach (var comment in comments)
            {
                sumRating += comment.Rating;
            }

            return sumRating / comments.Count();
        }

        private bool CanModifyComment(Comment comment)
        {
            if (comment == null)
            {
                return false;
            }

            return comment.UserId == this.userContext.UserAccountId || this.userContext.IsInRole(UserRole.Admin);
        }
    }
}
