using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.DeleteImage
{
    public class DeleteProductImageCommandHandler:IBaseCommandHandler<DeleteProductImageCommand>
    {
        public DeleteProductImageCommandHandler(IProductRepository repository, ILocalFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        private readonly IProductRepository _repository;
        private readonly ILocalFileService _localFileService;
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
                _localFileService.DeleteFile(Directories.ProductGalleryImages, imageName);
                return OperationResult.Success();
            }
        }
    }
}