namespace Shop.Domain.ProductAgg.Services
{
    public interface IDomainProductService
    {
        bool SlugIsExist(string slug);
    }
}