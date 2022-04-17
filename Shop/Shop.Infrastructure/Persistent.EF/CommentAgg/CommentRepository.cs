using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.EF.CommentAgg
{
    public class CommentRepository:BaseRepository<Comment>,ICommentRepository
    {
        public CommentRepository(ShopContext context) : base(context)
        {
        }
    }
}