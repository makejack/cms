using System.Collections.Generic;
namespace www.veinid365.cn.Models.Admin.Response
{
    public class PageContentDetailResponse : AggregateModel
    {
        public int NavMenuId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string Title { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        /// <value></value>
        public string Thumbnail { get; set; }
        /// <summary>
        /// 富文本内容
        /// </summary>
        /// <value></value>
        public string Content { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        /// <value></value>
        public bool IsPublished { get; set; }
        /// <summary>
        /// SEO标题
        /// </summary>
        /// <value></value>
        public string WebsiteTitle { get; set; }
        /// <summary>
        /// SEO关键词
        /// </summary>
        /// <value></value>
        public string WebsiteKeywords { get; set; }
        /// <summary>
        /// SEO描述
        /// </summary>
        /// <value></value>
        public string WebsiteDescription { get; set; }

        public virtual List<DownloadFilelResponse> DownloadFiles { get; set; }
    }
}