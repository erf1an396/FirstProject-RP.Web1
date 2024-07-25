﻿using FirstProject_RP.CoreLayer.DTOs.Posts;
using FirstProject_RP.CoreLayer.Utilities;
using FirstProject_RP.DataLayer.Entities;
using FirtsProject_RP.CoreLayer.Mappers;

namespace FirstProject_RP.CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto dto)
        {
            return new Post()
            {
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Slug = dto.Slug.ToSlug(),
                Title = dto.Title,
                UserId = dto.UserId = 1,
                Visit = 0,
                IsDeleted = false,
                SubCategoryId=dto.SubCategoryId
            };
        }
        public static PostDto MapToDto(Post post)
        {
            return new PostDto()
            {
                Description = post.Description,
                CategoryId = post.CategoryId,
                Slug = post.Slug,
                Title = post.Title,
                UserId = post.UserId,
                Visit = post.Visit,
                CreationDate = post.CreationDate,
                Category = CategoryMapper.Map(post.Category),
                ImageName = post.ImageName,
                PostId = post.Id,
                SubCategoryId = post.SubCategoryId,
                SubCategory = post.SubCategoryId == null ? null : CategoryMapper.Map(post.SubCategory)
            };
        }
        public static Post EditPost(EditPostDto editDto, Post post)
        {
            post.Description = editDto.Description;
            post.Title = editDto.Title;
            post.CategoryId = editDto.CategoryId;
            post.Slug = editDto.Slug.ToSlug();
            post.SubCategoryId = editDto.SubCategoryId;
            return post;
        }
    }
}