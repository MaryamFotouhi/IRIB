using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommand:IBaseCommand
    {
        public AddChildCategoryCommand(long id, string title, string slug, SeoData seoData)
        {
            Id = id;
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }

    }
}