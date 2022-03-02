using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repositiry;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    internal class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
    {
        public EditBannerCommandHandler(IBannerRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        private readonly IBannerRepository _repository;
        private readonly IFileService _fileService;
        public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetTracking(request.Id);
            if (banner == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                var imageName = banner.ImageName;
                var oldImageName = banner.ImageName;
                if (request.ImageFile != null)
                {
                    imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
                }
                banner.Edit(request.Link, imageName, request.Position);
                await _repository.Save();
                RemoveOldImage(request.ImageFile, oldImageName);
                return OperationResult.Success();
            }
        }
        private void RemoveOldImage(IFormFile imageFile, string oldImageName)
        {
            if (imageFile != null)
            {
                _fileService.DeleteFile(Directories.ProductImages, oldImageName);
            }
        }
    }
}