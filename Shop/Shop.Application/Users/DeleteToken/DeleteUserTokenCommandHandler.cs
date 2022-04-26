using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.DeleteToken
{
    internal class DeleteUserTokenCommandHandler : IBaseCommandHandler<DeleteUserTokenCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(DeleteUserTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            user.DeleteToken(request.Id);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}

