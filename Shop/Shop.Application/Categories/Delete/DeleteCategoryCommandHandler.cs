using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CategoryAgg.Repository;

namespace Shop.Application.Categories.Delete
{
    public class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.DeleteCategory(request.CategoryId);
            return result ? OperationResult.Success() : OperationResult.Error("امکان حذف این دسته بندی وجود ندارد!");
        }
    }
}