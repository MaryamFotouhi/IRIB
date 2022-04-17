using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter
{
    public class GetCommentsByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
    {
        public GetCommentsByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
        {
        }
    }
}