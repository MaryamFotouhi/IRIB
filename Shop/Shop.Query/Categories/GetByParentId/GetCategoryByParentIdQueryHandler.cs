using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Categories.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetByParentId
{
    internal class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<ChildCategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryByParentIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories
                .Include(c => c.Children)
                .Where(p => p.ParentId == request.ParentId)
                .ToListAsync(cancellationToken);
            return result.MapChildren();
        }
    }
}