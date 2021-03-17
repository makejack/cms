using System.Collections.Generic;
using www.veinid365.cn.Data.Entities;
using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Request
{
    public class NavMenuCreateEditRequest
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public int Order { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        /// <value></value>
        public NavMenuTypes Type { get; set; }
        /// <summary>
        /// 外部地址
        /// </summary>
        /// <value></value>
        public string ExternalUrl { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        /// <value></value>
        public string MenuName { get; set; }
        /// <summary>
        /// 英文别名
        /// </summary>
        /// <value></value>
        public string EnMenuName { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        /// <value></value>
        public bool IsHidden { get; set; }
        /// <summary>
        /// 横幅图片
        /// </summary>
        /// <value></value>
        public string BannerImg { get; set; }
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
        /// <summary>
        /// 导航模型
        /// </summary>
        /// <value></value>
        public NavMenuModels Model { get; set; }
        /// <summary>
        /// 模板文件
        /// </summary>
        /// <value></value>
        public string ListTemplateFile { get; set; }
        /// <summary>
        /// 内容模板文件
        /// </summary>
        /// <value></value>
        public string ContentTemplateFile { get; set; }

        public List<WebsiteCustomFormCreateEditRequest> WebsiteCustomForms { get; set; }
    }
}