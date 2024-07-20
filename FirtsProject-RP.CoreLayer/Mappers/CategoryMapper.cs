using FirstProject_RP.DataLayer.Entities;
using FirtsProject_RP.CoreLayer.DTOs.Categories;

namespace FirtsProject_RP.CoreLayer.Mappers;

public class CategoryMapper
{
    public static CategoryDto Map(Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            MetaDescription = category.MetaDescription,
            MetaTag = category.MetaTag,
            ParentId = category.ParentId,
            Slug = category.Slug,
            Title = category.Title,
        };
    }
}