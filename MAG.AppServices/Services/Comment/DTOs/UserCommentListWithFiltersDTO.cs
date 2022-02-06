using System.Collections.Generic;

namespace MAG.AppServices
{
    public class UserCommentListWithFiltersDTO : BaseReturnedListWithFilters
    {
        public List<UserCommentInListDTO> CommentList { get; set; }
    }
}
