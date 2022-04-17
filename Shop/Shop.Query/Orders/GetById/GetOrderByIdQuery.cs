using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById
{
    public class GetOrderByIdQuery:IQuery<OrderDto>
    {
        public GetOrderByIdQuery(long orderId)
        {
            OrderId = orderId;
        }

        public long OrderId { get; private set; } 
    }
    public class GetOrderByIdQueryHandler:IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        public GetOrderByIdQueryHandler(ShopContext shopContext, DapperContext dapperContext)
        {
            _shopContext = shopContext;
            _dapperContext = dapperContext;
        }

        private readonly ShopContext _shopContext;
        private readonly DapperContext _dapperContext;
        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _shopContext.Orders
                .FirstOrDefaultAsync(f => f.Id == request.OrderId, cancellationToken);
            if (order == null)
            {
                return null;
            }
            var orderDto = order.Map();
            orderDto.UserFullName = await _shopContext.Users.Where(f => f.Id == orderDto.UserId)
                .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);
            orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
            return orderDto;
        }
    }
}