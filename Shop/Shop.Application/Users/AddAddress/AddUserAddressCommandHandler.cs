using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddAddress
{
    internal class AddUserAddressCommandHandler : IBaseCommandHandler<AddUserAddressCommand>
    {
        private readonly IUserRepository _repository;

        public AddUserAddressCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            var address = new UserAddress(request.Shire, request.City, request.PostalCode,
                request.PostalAddress, request.PhoneNumber, request.Name, request.Family,
                request.NationalCode);
            if (user == null)
                return OperationResult.NotFound();

            user.AddAddress(address);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}