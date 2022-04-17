using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByFilter
{
    public class GetSellerByFilterQueryHandler:IQueryHandler<GetSellerByFilterQuery,SellerFilterResult>
    {
        public GetSellerByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;
        public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Sellers.OrderByDescending(d => d.CreationDate).AsQueryable();
            if (!string.IsNullOrWhiteSpace(@params.ShopName))
            {
                result = result.Where(r => r.ShopName.Contains(@params.ShopName));
            }
            if (!string.IsNullOrWhiteSpace(@params.NationalCode))
            {
                result = result.Where(r => r.NationalCode.Contains(@params.NationalCode));
            }
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new SellerFilterResult()
            {
                Data = await result.Skip(skip).Take(@params.Take).Select(s => s.Map())
                    .ToListAsync(cancellationToken),
                FilterParams = @params
            };
            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}