#nullable enable
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Categories.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetById
{
    internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto?>
    {
        private readonly ShopContext _context;

        public GetCategoryByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken);
            return result.Map();
        }
    }
}