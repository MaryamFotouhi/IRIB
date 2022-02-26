using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommandHandler:IBaseCommandHandler<AddProductImageCommand>
    {
        public AddProductImageCommandHandler(IProductRepository repository, ILocalFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        private readonly IProductRepository _repository;
        private readonly ILocalFileService _localFileService;
        public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var product =await _repository.GetTracking(request.ProductId);
            if (product == null)
            {
                return  OperationResult.NotFound();
            }
            else
            {
                var imageName =await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImages);
                var productImage=new ProductImage(imageName,request.Sequence);
                product.AddImage(productImage);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}