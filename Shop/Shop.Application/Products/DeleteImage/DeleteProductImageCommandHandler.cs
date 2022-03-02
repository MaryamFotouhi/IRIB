using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.DeleteImage
{
    internal class DeleteProductImageCommandHandler:IBaseCommandHandler<DeleteProductImageCommand>
    {
        public DeleteProductImageCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;
        public async Task<OperationResult> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                var imageName=product.DeleteImage(request.ImageId);
                await _repository.Save();
                _fileService.DeleteFile(Directories.ProductGalleryImages, imageName);
                return OperationResult.Success();
            }
        }
    }
}