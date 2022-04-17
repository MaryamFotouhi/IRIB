using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repositiry;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        private readonly ISliderRepository _repository;
        private readonly IFileService _fileService;

        public EditSliderCommandHandler(ISliderRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _repository.GetTracking(request.Id);
            if (slider == null)
                return OperationResult.NotFound();

            var imageName = slider.ImageName;
            var oldImageName = slider.ImageName;
            if (request.ImageFile != null)
                imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            slider.Edit(request.Title, request.Link, imageName);
            await _repository.Save();
            if (request.ImageFile != null)
                _fileService.DeleteFile(Directories.SliderImages, oldImageName);
            //RemoveOldImage(request.ImageFile, oldImageName);
            return OperationResult.Success();
        }
        //private void RemoveOldImage(IFormFile imageFile, string oldImageName)
        //{
        //    if (imageFile != null)
        //    {
        //        _fileService.DeleteFile(Directories.SliderImages, oldImageName);
        //    }
        //}
    }
}