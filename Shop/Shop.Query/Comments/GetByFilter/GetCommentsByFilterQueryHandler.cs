using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Comments.DTOs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Comments.GetByFilter
{
    internal class GetCommentsByFilterQueryHandler : IQueryHandler<GetCommentsByFilterQuery, CommentFilterResult>
    {
        private readonly ShopContext _context;

        public GetCommentsByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CommentFilterResult> Handle(GetCommentsByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Comments
                .OrderByDescending(d => d.CreationDate).AsQueryable();
            if (@params.UserId != null)
            {
                result=result.Where(u => u.UserId == @params.UserId);
            }
            if (@params.StartDate != null)
            {
                result=result.Where(s => s.CreationDate >= @params.StartDate.Value.Date);
            }
            if (@params.EndDate != null)
            {
                result=result.Where(e => e.CreationDate <= @params.EndDate.Value.Date);
            }
            if (@params.Status != null)
            {
                result=result.Where(s => s.Status == @params.Status);
            }
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new CommentFilterResult
            {
                Data = await result.Skip(skip).Take(@params.Take)
                    .Select(c => c.MapFilterComment())
                    .ToListAsync(cancellationToken),
                FilterParams = @params
            };
            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}