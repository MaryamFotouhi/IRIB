using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Edit
{
    internal class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public EditRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetTracking(request.Id);
            if (role == null)
                return OperationResult.NotFound();

            role.Edit(request.Title);
            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(permission =>
            {
                permissions.Add(new RolePermission(permission));
            });
            role.SetPermissions(permissions);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}