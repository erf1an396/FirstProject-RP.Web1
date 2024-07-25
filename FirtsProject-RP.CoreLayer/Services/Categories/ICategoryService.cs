using System.Net;

using FirstProject_RP.CoreLayer.Utilities;
using FirtsProject_RP.CoreLayer.DTOs.Categories;

namespace FirtsProject_RP.CoreLayer.Services.Categories;

public interface ICategoryService
{
    OperationResult CreateCategory(CreateCategoryDto command);

    OperationResult EditCategory(EditCategoryDto  command);

    List<CategoryDto> GetChildCategories(int parentID);

    List<CategoryDto> GetAllCategory();

    CategoryDto GetCategoryBy (int id );

    CategoryDto GetCategoryBy(string slug);

    bool IsSlugExist (string slug);


}