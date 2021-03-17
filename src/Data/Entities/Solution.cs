using System;
using System.ComponentModel.DataAnnotations;
namespace www.veinid365.cn.Data.Entities
{
    public class Solution : Aggregate
    {
        public Solution()
        {
        }

        public Solution(int categoryId, string imageUrl, string title, string content, bool isPublished)
        {
            Edit(categoryId, imageUrl, title, content, isPublished);
        }


        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [MaxLength(512)]
        public string ImageUrl { get; set; }
        /// <summary>
        /// 中文标题
        /// </summary>
        [Required]
        [MaxLength(512)]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int Pageviews { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublished { get; set; }
        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        /// <value></value>
        public DateTime LastUpdateTime { get; set; }

        public void Edit(int categoryId, string iamgeUrl, string title, string content, bool isPublished)
        {
            this.CategoryId = categoryId;
            this.ImageUrl = iamgeUrl;
            this.Title = title;
            this.Content = content;
            this.IsPublished = isPublished;
            this.LastUpdateTime = DateTime.Now;
        }
    }
}