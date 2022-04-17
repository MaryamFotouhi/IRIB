using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit
{
    internal class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _domainService;
        private readonly IFileService _fileService;

        public EditUserCommandHandler(IUserRepository repository, IUserDomainService domainService, IFileService fileService)
        {
            _repository = repository;
            _domainService = domainService;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.Id);
            if (user == null)
                return OperationResult.NotFound();

            var oldImageName = user.AvatarName;
            user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _domainService);
            if (request.Avatar != null)
            {
                var imageName =
                    await _fileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatars);
                user.SetAvatar(imageName);
            }
            await _repository.Save();
            RemoveOldImage(request.Avatar, oldImageName);
            return OperationResult.Success();
        }
        private void RemoveOldImage(IFormFile imageFile, string oldImageName)
        {
            if (imageFile == null || oldImageName.Equals("Avatar.png"))
            {
                return;
            }
            else
            {
                _fileService.DeleteFile(Directories.UserAvatars, oldImageName);
            }
        }
    }
}