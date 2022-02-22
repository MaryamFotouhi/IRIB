namespace Shop.Domain.CategoryAgg.Services
{
    public interface IDomainCategoryService
    {
        bool SlugIsExist(string slug);
    }
}