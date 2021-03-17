using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace www.veinid365.cn.Data.Entities
{
    public class News : Aggregate
    {
        public News()
        {
        }

        public News(string imageUrl, string title, string content, bool isPublished)
        {
            Edit(imageUrl, title, content, isPublished);
        }

        [MaxLength(512)]
        public string ImageUrl { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(512)]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        /// <value></value>
        public DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        /// <value></value>
        public int Pageviews { get; set; }
        public bool IsPublished { get; set; }

        public void Edit(string imageUrl, string title, string content, bool isPublished)
        {
            this.ImageUrl = imageUrl;
            this.Title = title;
            this.Content = content;
            this.LastUpdateTime = DateTime.Now;
            this.IsPublished = isPublished;
        }
    }
}