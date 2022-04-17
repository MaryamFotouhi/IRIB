using System;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;
using System.Threading.Tasks;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ShopContext context, DapperContext dapperContext) : base(context)
        {
            _dapperContext = dapperContext;
        }

        private readonly DapperContext _dapperContext;

        //public async Task<SellerInventoryResult?> GetInventoryById(long id)
        //{
        //    return await Context.Inventories.Where(r => r.Id == id)
        //        .Select(i => new InventoryResult()
        //        {
        //            Count = i.Count,
        //            Id = i.Id,
        //            Price = i.Price,
        //            ProductId = i.ProductId,
        //            SellerId = i.SellerId
        //        }).FirstOrDefaultAsync();
        //}
        public async Task<SellerInventoryResult> GetInventoryById(long id)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT * FROM {_dapperContext.Inventories} WHERE Id=@inventoryId";
            var result =await connection.QueryFirstOrDefaultAsync<SellerInventoryResult>(sql, new { inventoryId = id});
            return result;
        }
    }
}

