using Common.Application;
using FluentValidation;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products.DeleteImage
{
    public class DeleteProductImageCommand:IBaseCommand
    {
        public long ProductId { get; private set; }
        public long ImageId { get; private set; }

        public DeleteProductImageCommand(long productId, long imageId)
        {
            ProductId = productId;
            ImageId = imageId;
        }
    }
}