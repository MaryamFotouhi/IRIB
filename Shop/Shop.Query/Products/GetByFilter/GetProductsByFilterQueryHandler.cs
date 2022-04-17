using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Products.DTOs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Products.GetByFilter
{
    internal class GetProductsByFilterQueryHandler : IQueryHandler<GetProductsByFilterQuery, ProductFilterResult>
    {
        public GetProductsByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;
        public async Task<ProductFilterResult> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Products.OrderByDescending(d => d.CreationDate).AsQueryable();
            if (!string.IsNullOrWhiteSpace(@params.Slug))
            {
                result = result.Where(r => r.Slug == @params.Slug);
            }
            if (!string.IsNullOrWhiteSpace(@params.Title))
            {
                result = result.Where(r => r.Title.Contains(@params.Title));
            }
            if (@params.Id != null)
            {
                result = result.Where(r => r.Id == @params.Id);
            }
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new ProductFilterResult()
            {
                Data = await result.Skip(skip).Take(@params.Take).Select(s => s.MapListData())
                    .ToListAsync(cancellationToken),
                FilterParams = @params
            };
            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}

