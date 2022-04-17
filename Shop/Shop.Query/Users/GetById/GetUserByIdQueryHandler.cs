using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Users.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Query.Users.GetById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
    {
        public GetUserByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;
        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                return null;

            }
            else
            {
                return await user.Map().SetUserRoleTitles(_context);
            }
        }
    }
}

