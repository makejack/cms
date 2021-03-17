using System;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class NewsListResponse : AggregateModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string Title { get; set; }
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
    }
}