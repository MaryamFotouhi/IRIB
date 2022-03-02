using System.Collections.Generic;
using Common.Application;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Application.Roles.Edit
{
    public class EditRoleCommand:IBaseCommand
    {
        public EditRoleCommand(long id, string title, List<Permission> permissions)
        {
            Id = id;
            Title = title;
            Permissions = permissions;
        }

        public long Id { get; private set; }
        public string Title { get; private set; }
        public List<Permission> Permissions { get; private set; }
    }
}