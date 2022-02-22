using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage:BaseEntity
    {
        private ProductImage()
        {

        }
        public ProductImage(long productId, string imageName, int sequence)
        {
            NullOrEmptyDomainDataException.CheckString(imageName,nameof(imageName));
            ProductId = productId;
            ImageName = imageName;
            Sequence = sequence;
        }

        public long ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public int Sequence { get; private set; }
    }
}