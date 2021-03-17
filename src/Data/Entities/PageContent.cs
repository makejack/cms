using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Data.Entities
{
    public class PageContent : Aggregate
    {
        public int NavMenuId { get; set; }
        public virtual NavMenu NavMenu { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(512)]
        public string Title { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        /// <value></value>
        [MaxLength(512)]
        public string Thumbnail { get; set; }
        /// <summary>
        /// 富文本内容
        /// </summary>
        /// <value></value>
        public string Content { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        /// <value></value>
        public int Pageviews { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        /// <value></value>
        public bool IsPublished { get; set; }
        /// <summary>
        /// SEO标题
        /// </summary>
        /// <value></value>
        [MaxLength(128)]
        public string WebsiteTitle { get; set; }
        /// <summary>
        /// SEO关键词
        /// </summary>
        /// <value></value>
        [MaxLength(256)]
        public string WebsiteKeywords { get; set; }
        /// <summary>
        /// SEO描述
        /// </summary>
        /// <value></value>
        [MaxLength(512)]
        public string WebsiteDescription { get; set; }

        public virtual List<DownloadFile> DownloadFiles { get; set; }


        public void Edit(int navMenuId,
                         string title,
                         string thumbnail,
                         string content,
                         bool isPublished,
                         string websiteTitle,
                         string websiteKeywords,
                         string websiteDescription,
                         List<DownloadFile> downloadFiles)
        {
            NavMenuId = navMenuId;
            Title = title;
            Thumbnail = thumbnail;
            Content = content;
            IsPublished = isPublished;
            WebsiteTitle = websiteTitle;
            WebsiteKeywords = websiteKeywords;
            WebsiteDescription = websiteDescription;
            DownloadFiles = downloadFiles;
        }

        public void IncreasePageviews()
        {
            this.Pageviews++;
        }

    }
}