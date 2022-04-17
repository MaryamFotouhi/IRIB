using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories
{
    public class CategoryDomainService:ICategoryDomainService
    {
        private readonly ICategoryRepository _repository;

        public CategoryDomainService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public bool SlugIsExist(string slug)
        {
            return _repository.Exists(c => c.Slug == slug);
        }
    }
}