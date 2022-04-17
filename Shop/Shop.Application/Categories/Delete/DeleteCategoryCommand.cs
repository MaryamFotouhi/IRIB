using Common.Application;

namespace Shop.Application.Categories.Delete
{
    public class DeleteCategoryCommand: IBaseCommand
    {
        public long CategoryId { get; private set; }

        public DeleteCategoryCommand(long categoryId)
        {
            CategoryId = categoryId;
        }
    }
}

