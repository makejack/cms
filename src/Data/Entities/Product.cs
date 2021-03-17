using System;
using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Data.Entities
{
    public class Product : Aggregate
    {
        public Product()
        {
        }

        public Product(int categoryId, string imageUrl, string title, string content, bool isPublished)
        {
            Edit(categoryId, imageUrl, title, content, isPublished);
        }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [MaxLength(512)]
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(512)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        /// <value></value>
        public int Pageviews { get; set; }
        public bool IsPublished { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public void Edit(int categoryId, string imageUrl, string title, string content, bool isPublished)
        {
            this.CategoryId = categoryId;
            this.ImageUrl = imageUrl;
            this.Title = title;
            this.Content = content;
            this.IsPublished = isPublished;
            LastUpdateTime = DateTime.Now;
        }
    }
}