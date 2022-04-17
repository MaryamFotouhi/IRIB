using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetById
{
    public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto>
    {
        public GetRoleByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;
        public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken);
            if (role == null)
            {
                return null;
            }
            else
            {
                return new RoleDto()
                {
                    Id = role.Id,
                    CreationDate = role.CreationDate,
                    Title = role.Title,
                    Permissions = role.Permissions.Select(p=>p.Permission).ToList()
                };
            }
        }
    }
}