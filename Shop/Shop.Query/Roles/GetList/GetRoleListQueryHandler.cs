using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetList
{
    public class GetRoleListQueryHandler : IQueryHandler<GetRoleListQuery, List<RoleDto>>
    {
        public GetRoleListQueryHandler(ShopContext context)
        {
            _context = context;
        }

        private readonly ShopContext _context;
        public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Roles.OrderByDescending(d => d.CreationDate)
                .Select(r => new RoleDto()
                {
                    Id = r.Id,
                    CreationDate = r.CreationDate,
                    Title = r.Title,
                    Permissions = r.Permissions.Select(p => p.Permission).ToList()

                }).ToListAsync(cancellationToken);
        }
    }
}