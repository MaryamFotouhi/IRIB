using Common.Query;
using Shop.Query.Products;
using Shop.Query.Products.DTOs;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByFilter
{
    public class GetSellerByFilterQuery:QueryFilter<SellerFilterResult,SellerFilterParams>
    {
        public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
        {
        }
    }
}