using MAG.Database;
using System.Threading.Tasks;

namespace MAG.AppServices
{
    public interface ICommentService
    {
        Task<bool> InsertComment(InsertUpdateCommentDTO comment);
        Task<Comment> GetComment(long userId, long gameId);
        Task<UserCommentListWithFiltersDTO> GetAllComments(CommentsFiltersDTO commentsFilters);
        Task<bool> UpdateComment(InsertUpdateCommentDTO comment);
        Task<bool> DeleteComment(long userId, long gameId);
        bool HasUserAlreadyCommented(long gameId);
    }
}
