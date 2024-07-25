using FirstProject_RP.CoreLayer.Utilities;
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

        if(IsSlugExist(command.Slug))
            return OperationResult.Error("Slug Is Exist");

        var Category = new Category()
        {
            Title = command.Title,
            IsDeleted = false,
            Slug = command.Slug.ToSlug(),
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

        if (command.Slug.ToSlug() != category.Slug)
            if (IsSlugExist(command.Slug))
                return OperationResult.Error("Slug Is Exist");

        category.Title = command.Title;
         category.Slug = command.Slug.ToSlug();
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

    public List<CategoryDto> GetChildCategories(int parentId)
    {
        return _blogContext.Categories.Where(r => r.ParentId == parentId).Select(category => CategoryMapper.Map(category)).ToList();
    }

    public bool IsSlugExist(string slug)
     {
         return _blogContext.Categories.Any(c => c.Slug == slug.ToSlug());
     }

     
}