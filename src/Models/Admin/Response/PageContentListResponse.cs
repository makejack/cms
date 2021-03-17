using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class PageContentListResponse : AggregateModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string Title { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        /// <value></value>
        public bool IsPublished { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        /// <value></value>
        public int Pageviews { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        /// <value></value>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单模板
        /// </summary>
        /// <value></value>
        public NavMenuModels MenuModel { get; set; }
    }
}