using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler:IBaseCommandHandler<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandHandler(ICategoryRepository repository, IDomainCategoryService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        private readonly ICategoryRepository _repository;
        private readonly IDomainCategoryService _domainService;
        public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                category.AddChild(request.Title, request.Slug, request.SeoData, _domainService);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}