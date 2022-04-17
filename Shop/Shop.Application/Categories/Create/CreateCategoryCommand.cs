using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommand : IBaseCommand<long>
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }

        public CreateCategoryCommand(string title, string slug, SeoData seoData)
        {
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }
    }
}