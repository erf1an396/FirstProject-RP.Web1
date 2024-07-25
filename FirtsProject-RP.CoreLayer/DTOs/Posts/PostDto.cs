﻿using System;

using FirtsProject_RP.CoreLayer.DTOs.Categories;

namespace FirstProject_RP.CoreLayer.DTOs.Posts
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int Visit { get; set; }
        public DateTime CreationDate { get; set; }
        public CategoryDto Category { get; set; }
        public CategoryDto SubCategory { get; set; }
    }
}