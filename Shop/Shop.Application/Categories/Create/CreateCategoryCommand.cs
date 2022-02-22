using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommand:IBaseCommand
    {
        public CreateCategoryCommand(string title, string slug, SeoData seoData)
        {
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
    }
}