using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        private Product()
        {

        }
        public Product(string title, string imageName, string description, long categoryId,
            long subCategoryId, long secondarySubCategoryId, string slug, SeoData seoData,
            IDomainProductService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            Guard(title, description, slug, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }

        public void Edit(string title, string description, long categoryId,
            long subCategoryId, long secondarySubCategoryId, string slug, SeoData seoData,
            IDomainProductService domainService)
        {
            Guard(title, description, slug, domainService);
            Title = title;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        public void SetProductImage(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
        }
        public void AddImage(ProductImage image)
        {
            if (image == null)
            {
                throw new NullOrEmptyDomainDataException("Image Not Found");
            }
            image.ProductId = Id;
            Images.Add(image);
        }
        public string DeleteImage(long imageId)
        {
            var currentImage = Images.FirstOrDefault(i => i.Id == imageId);
            if (currentImage == null)
            {
                throw new NullOrEmptyDomainDataException("Image Not Found");
            }
            Images.Remove(currentImage);
            return currentImage.ImageName;
        }
        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(s => s.ProductId = Id);
            Specifications = specifications;
        }

        private void Guard(string title, string description, string slug, IDomainProductService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
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
