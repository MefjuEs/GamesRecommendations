using System.Collections.Generic;

namespace MAG.AppServices
{
    public class GameCommentListWithFiltersDTO : BaseReturnedListWithFilters
    {
        public List<GameCommentInListDTO> CommentList { get; set; }
    }
}
