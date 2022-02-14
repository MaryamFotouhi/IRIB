using Common.Domain;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg
{
    public class RolePermission:BaseEntity
    {
        private RolePermission()
        {

        }
        public RolePermission(long roleId, Permission permission)
        {
            RoleId = roleId;
            Permission = permission;
        }
        public long RoleId { get; internal set; }
        public Permission Permission { get; private set; }
    }
}