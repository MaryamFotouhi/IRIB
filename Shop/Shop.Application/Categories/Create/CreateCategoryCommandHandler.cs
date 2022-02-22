using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
    {
        public CreateCategoryCommandHandler(ICategoryRepository repository, IDomainCategoryService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        private readonly ICategoryRepository _repository;
        private readonly IDomainCategoryService _domainService;
        public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category=new Category(request.Title,request.Slug,request.SeoData,_domainService);
            await _repository.Add(category);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
}