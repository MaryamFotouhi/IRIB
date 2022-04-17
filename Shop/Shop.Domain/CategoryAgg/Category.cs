using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;
using System.Collections.Generic;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ParentId { get; private set; }
        public List<Category> Children { get; private set; }

        private Category()
        {

        }

        public Category(string title, string slug, SeoData seoData, ICategoryDomainService domainService)
        {
            Guard(title, slug, domainService);
            Title = title;
            Slug = slug.ToSlug();
            SeoData = seoData;
            Children = new List<Category>();
        }

        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService domainService)
        {
            Guard(title, slug, domainService);
            Title = title;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService domainService)
        {
            Children.Add(new Category(title, slug, seoData, domainService)
            {
                ParentId = Id
            });
        }
        private void Guard(string title, string slug, ICategoryDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            if (slug.ToSlug() != Slug)
            {
                if (domainService.SlugIsExist(slug.ToSlug()))
                {
                    throw new SlugIsDuplicateException();
                }
            }
        }

    }
}