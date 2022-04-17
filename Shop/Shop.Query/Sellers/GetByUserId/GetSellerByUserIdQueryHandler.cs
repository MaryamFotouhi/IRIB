#nullable enable
using System.Threading;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByUserId
{
    public class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
    {
        private readonly ShopContext _context;

        public GetSellerByUserIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.Id == request.UserId, cancellationToken);
            return seller.Map();
        }
    }
}