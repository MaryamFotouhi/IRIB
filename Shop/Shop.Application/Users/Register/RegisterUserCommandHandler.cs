using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Register
{
    internal class RegisterUserCommandHandler:IBaseCommandHandler<RegisterUserCommand>
    {
        public RegisterUserCommandHandler(IUserRepository repository, IDomainUserService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        private readonly IUserRepository _repository;
        private readonly IDomainUserService _domainService;
        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Register(request.PhoneNumber.Value, request.Password, _domainService);
            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}