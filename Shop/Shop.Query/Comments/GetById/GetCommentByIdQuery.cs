#nullable enable
using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById
{
    public class GetCommentByIdQuery:IQuery<CommentDto?>
    {
        public long CommentId { get; set; }

        public GetCommentByIdQuery(long commentId)
        {
            CommentId = commentId;
        }

    }
}