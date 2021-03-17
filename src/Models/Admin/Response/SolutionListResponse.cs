using System;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class SolutionListResponse : AggregateModel
    {
        /// <summary>
        /// 中文标题
        /// </summary>
        public string Title { get; set; }
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
    }
}