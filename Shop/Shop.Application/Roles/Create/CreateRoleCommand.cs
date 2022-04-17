using System.Collections.Generic;
using Common.Application;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Application.Roles.Create
{
    public class CreateRoleCommand : IBaseCommand
    {
        public string Title { get; private set; }
        public List<Permission> Permissions { get; private set; }

        public CreateRoleCommand(string title, List<Permission> permissions)
        {
            Title = title;
            Permissions = permissions;
        }
    }
}