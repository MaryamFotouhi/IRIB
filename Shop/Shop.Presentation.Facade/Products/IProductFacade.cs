using Common.Application;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Query.Products.DTOs;
using System.Threading.Tasks;
using Shop.Application.Products.DeleteImage;

namespace Shop.Presentation.Facade.Products
{
    public interface IProductFacade
    {
        Task<OperationResult> CreateProduct(CreateProductCommand command);
        Task<OperationResult> EditProduct(EditProductCommand command);
        Task<OperationResult> AddImage(AddProductImageCommand command);
        Task<OperationResult> DeleteImage(DeleteProductImageCommand command);

        Task<ProductDto?> GetProductById(long productId);
        Task<ProductDto?> GetProductBySlug(string slug);
        Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams);
        Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams);
    }
}

