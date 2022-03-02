using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Create
{
    internal class CreateUserCommandHandler:IBaseCommandHandler<CreateUserCommand>
    {
        public CreateUserCommandHandler(IUserRepository repository, IDomainUserService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        private readonly IUserRepository _repository;
        private readonly IDomainUserService _domainService;
        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user=new User(request.Name,request.Family,request.PhoneNumber,request.Email, password, request.Gender,_domainService);
            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}