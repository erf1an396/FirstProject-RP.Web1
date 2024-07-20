using CodeYad_Blog.CoreLayer.Utilities;
using FirstProject_RP.DataLayer.Context;
using FirstProject_RP.DataLayer.Entities;
using FirtsProject_RP.CoreLayer.DTOs.Categories;
using FirtsProject_RP.CoreLayer.Mappers;

namespace FirtsProject_RP.CoreLayer.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly BlogContext _blogContext;

    public CategoryService(BlogContext blogContext)
    {
        _blogContext = blogContext;
    }

   
    public OperationResult CreateCategory(CreateCategoryDto command)
    {
        var Category = new Category()
        {
            Title = command.Title,
            IsDeleted = false,
            Slug = command.Slug,
            MetaDescription = command.MetaDescription,
            MetaTag = command.MetaTag
        };
        _blogContext.Categories.Add(Category);
        _blogContext.SaveChanges();
        return OperationResult.Success();
    }

    public OperationResult EditCategory(EditCategoryDto command)
     {
         var category = _blogContext.Categories.FirstOrDefault(c => c.Id == command.Id);

         if (category == null)
             return OperationResult.NotFound();

         category.Title = command.Title;
         category.Slug = command.Slug;
         category.MetaDescription = command.MetaDescription;
         category.MetaTag = command.MetaTag;


         //_blogContext.Update(category);
         _blogContext.SaveChanges();
         return OperationResult.Success();
     }

     public List<CategoryDto> GetAllCategory()
     {
         return _blogContext.Categories.Select(category => CategoryMapper.Map(category)).ToList();
     }

     public CategoryDto GetCategoryBy(int id)
     {
         var category = _blogContext.Categories.FirstOrDefault(c => c.Id == id);
         if (category == null)
             return null;
         return CategoryMapper.Map(category);
     }

     public CategoryDto GetCategoryBy(string slug)
     {
        var category = _blogContext.Categories.FirstOrDefault(c => c.Slug == slug);
        if (category == null)
            return null;
        return CategoryMapper.Map(category);
    }
}