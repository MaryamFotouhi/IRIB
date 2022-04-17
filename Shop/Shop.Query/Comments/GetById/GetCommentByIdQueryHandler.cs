#nullable enable
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Comments.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Comments.GetById
{
    internal class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
    {
        private readonly ShopContext _context;

        public GetCommentByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Comments.
                FirstOrDefaultAsync(c => c.Id == request.CommentId, cancellationToken);
            return result.Map();
        }
    }
}