namespace Shop.Domain.CategoryAgg.Services
{
    public interface ICategoryDomainService
    {
        bool SlugIsExist(string slug);
    }
}