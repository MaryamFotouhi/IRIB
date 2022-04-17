using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Products.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Products.GetById
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
    {
        public GetProductByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;
        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(f => f.Id == request.ProductId, cancellationToken);

            var model = product.Map();
            if (model == null)
            {
                return null;
            }
            await model.SetCategories(_context);
            return model;
        }
    }
}

