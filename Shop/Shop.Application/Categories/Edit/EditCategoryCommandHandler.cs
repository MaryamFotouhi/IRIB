using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandHandler:IBaseCommandHandler<EditCategoryCommand>
    {
        public EditCategoryCommandHandler(ICategoryRepository repository, IDomainCategoryService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        private readonly ICategoryRepository _repository;
        private readonly IDomainCategoryService _domainService;
        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category =await _repository.GetTracking(request.Id);
            if (category == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                category.Edit(request.Title,request.Slug,request.SeoData,_domainService);
                //_repository.Update(category);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}