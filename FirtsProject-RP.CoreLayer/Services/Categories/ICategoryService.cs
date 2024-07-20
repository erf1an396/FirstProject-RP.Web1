using System.Net;
using CodeYad_Blog.CoreLayer.Utilities;
using FirtsProject_RP.CoreLayer.DTOs.Categories;

namespace FirtsProject_RP.CoreLayer.Services.Categories;

public interface ICategoryService
{
    OperationResult CreateCategory(CreateCategoryDto command);

    OperationResult EditCategory(EditCategoryDto  command);

    List<CategoryDto> GetAllCategory();

    CategoryDto GetCategoryBy (int id );

    CategoryDto GetCategoryBy(string slug);


}