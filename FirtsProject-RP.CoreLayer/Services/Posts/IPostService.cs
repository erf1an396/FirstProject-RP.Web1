
using FirstProject_RP.CoreLayer.DTOs.Posts;
using FirtsProject_RP.CoreLayer.DTOs;
using FirstProject_RP.CoreLayer.Utilities;
using FirstProject_RP.DataLayer.Entities;

namespace FirstProject_RP.CoreLayer.Services.Posts
{
    public interface IPostService
    {
        OperationResult CreatePost(CreatePostDto command);
        OperationResult EditPost(EditPostDto command);
        PostDto GetPostById(int postId);
        PostFilterDto GetPostsByFilter(PostFilterParams filterParams);
        bool IsSlugExist(string slug);
    }
}