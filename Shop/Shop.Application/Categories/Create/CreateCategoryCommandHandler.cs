using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Create
{
    internal class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand,long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category=new Category(request.Title,request.Slug,request.SeoData,_domainService);
             _repository.Add(category);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }
}