using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Edit
{
    internal class EditProductCommandHandler:IBaseCommandHandler<EditProductCommand>
    {
        public EditProductCommandHandler(IProductRepository repository, IDomainProductService domainService,
            IFileService fileService)
        {
            _repository = repository;
            _domainService = domainService;
            _fileService = fileService;
        }

        private readonly IProductRepository _repository;
        private readonly IDomainProductService _domainService;
        private readonly IFileService _fileService;
        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                product.Edit(request.Title,request.Description,request.CategoryId,request.SubCategoryId,
                    request.SecondarySubCategoryId,request.Slug,request.SeoData,_domainService);
                var oldImageName = product.ImageName;
                if (request.ImageFile != null)
                {
                    var imageName =
                        await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
                    product.SetProductImage(imageName);
                }
                var specifications = new List<ProductSpecification>();
                request.Specifications.ToList().ForEach(specification =>
                {
                    specifications.Add(new ProductSpecification(specification.Key, specification.Value));
                });
                product.SetSpecification(specifications);
                await _repository.Save();
                RemoveOldImage(request.ImageFile,oldImageName);
                return OperationResult.Success();
            }
        }
        private void RemoveOldImage(IFormFile imageFile, string oldImageName)
        {
            if (imageFile != null)
            {
                _fileService.DeleteFile(Directories.ProductImages,oldImageName);
            }
        }
    }
}