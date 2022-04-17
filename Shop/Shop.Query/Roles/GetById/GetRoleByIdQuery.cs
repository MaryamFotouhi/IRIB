using Common.Query;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetById
{
    public class GetRoleByIdQuery:IQuery<RoleDto>
    {
        public GetRoleByIdQuery(long roleId)
        {
            RoleId = roleId;
        }

        public long RoleId { get; private set; }
    }
} 