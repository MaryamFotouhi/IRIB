#nullable enable
using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.Inventories.GetById
{
    internal class GetSellerInventoryByIdQueryHandler : IQueryHandler<GetSellerInventoryByIdQuery, InventoryDto?>
    {

        private readonly DapperContext _context;

        public GetSellerInventoryByIdQueryHandler(DapperContext context)
        {
            _context = context;
        }

        public async Task<InventoryDto?> Handle(GetSellerInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = _context.CreateConnection();

            var sql = @$"SELECT Top(1) i.Id,SellerId,ProductId,Count,Price,i.CreationDate,DiscountPercentage,s.ShopName,
                        p.Title AS ProductTitle,p.ImageName AS ProductImage
            FROM {_context.Inventories} i INNER JOIN {_context.Sellers} s ON i.SellerId=s.Id  
            INNER JOIN {_context.Products} p ON i.ProductId=p.Id WHERE i.Id=@id";

            var inventory = await connection.QueryFirstOrDefaultAsync<InventoryDto?>(sql, new { id = request.InventoryId });

            return inventory;
        }
    }
}

