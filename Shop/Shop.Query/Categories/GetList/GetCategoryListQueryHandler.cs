using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Categories.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetList
{
    internal class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories
                .Where(c=>c.ParentId==null)
                .Include(c=>c.Children)
                .ThenInclude(c => c.Children)
                .OrderByDescending(d => d.CreationDate)
                .ToListAsync(cancellationToken);
            return result.Map();
        }
    }
}