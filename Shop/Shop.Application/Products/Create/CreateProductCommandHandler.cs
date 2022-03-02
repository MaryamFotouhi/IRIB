using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create
{
    internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        public CreateProductCommandHandler(IProductRepository repository, IDomainProductService domainService,
            IFileService fileService)
        {
            _repository = repository;
            _domainService = domainService;
            _fileService = fileService;
        }

        private readonly IProductRepository _repository;
        private readonly IDomainProductService _domainService;
        private readonly IFileService _fileService;
        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            var product = new Product(request.Title, imageName, request.Description, request.CategoryId,
                request.SubCategoryId, request.SecondarySubCategoryId, request.Slug, request.SeoData, _domainService);
             _repository.Add(product);
            var specifications=new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecification(specifications);
 
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}