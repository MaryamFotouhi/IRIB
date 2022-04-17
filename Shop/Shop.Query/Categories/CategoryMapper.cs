#nullable enable
using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;
using System.Collections.Generic;

namespace Shop.Query.Categories
{
    internal static class CategoryMapper
    {
        public static CategoryDto? Map(this Category? category)
        {
            if (category == null)
            {
                return null;
            }
            return new CategoryDto()
            {
                Title = category.Title,
                Slug = category.Slug,
                SeoData = category.SeoData,
                CreationDate = category.CreationDate,
                Children = category.Children.MapChildren()
            };
        }

    public static List<CategoryDto> Map(this List<Category> categories)
    {
        var model = new List<CategoryDto>();
        categories.ForEach(c =>
        {
            model.Add(new CategoryDto()
            {
                Id = c.Id,
                CreationDate = c.CreationDate,
                Title = c.Title,
                Slug = c.Slug,
                SeoData = c.SeoData,
                Children = c.Children.MapChildren()
            });
        });
        return model;
    }

    public static List<ChildCategoryDto> MapChildren(this List<Category> children)
    {
        var model = new List<ChildCategoryDto>();
        children.ForEach(c =>
        {
            model.Add(new ChildCategoryDto()
            {
                Id = c.Id,
                CreationDate = c.CreationDate,
                Title = c.Title,
                Slug = c.Slug,
                SeoData = c.SeoData,
                ParentId = (long)c.ParentId,
                Children = c.Children.MapSecondaryChildren()
            });
        });
        return model;
    }

    private static List<SecondaryChildCategoryDto> MapSecondaryChildren(this List<Category> children)
    {
        var model = new List<SecondaryChildCategoryDto>();
        children.ForEach(c =>
        {
            model.Add(new SecondaryChildCategoryDto()
            {
                Id = c.Id,
                CreationDate = c.CreationDate,
                Title = c.Title,
                Slug = c.Slug,
                SeoData = c.SeoData,
            });
        });
        return model;
    }
}
}