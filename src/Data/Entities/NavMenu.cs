using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Data.Entities
{
    public class NavMenu : Aggregate
    {
        public NavMenu()
        {
        }

        public int? ParentId { get; set; }
        public virtual NavMenu Parent { get; set; }
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
        [MaxLength(512)]
        public string ExternalUrl { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(32)]
        public string MenuName { get; set; }
        /// <summary>
        /// 英文别名
        /// </summary>
        /// <value></value>
        [MaxLength(128)]
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
        [MaxLength(512)]
        public string BannerImg { get; set; }
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
        /// <summary>
        /// 导航模型
        /// </summary>
        /// <value></value>
        public NavMenuModels Model { get; set; }
        /// <summary>
        /// 列表模板文件
        /// </summary>
        /// <value></value>
        [MaxLength(512)]
        public string ListTemplateFile { get; set; }
        /// <summary>
        /// 内容模板文件
        /// </summary>
        /// <value></value>
        [MaxLength(512)]
        public string ContentTemplateFile { get; set; }

        public virtual List<NavMenu> Children { get; set; }
        public virtual List<WebsiteCustomForm> WebsiteCustomForms { get; set; }


        public void Edit(int? parentId,
                         int order,
                         NavMenuTypes type,
                         string externalUrl,
                         string menuName,
                         string enMenuName,
                         bool isHidden,
                         string bannerImg,
                         string websiteKeywords,
                         string websiteDescription,
                         NavMenuModels model,
                         string listTemplateFile,
                         string contentTemplateFile,
                         List<WebsiteCustomForm> websiteCustomForms)
        {
            ParentId = parentId;
            Order = order;
            Type = type;
            ExternalUrl = externalUrl;
            MenuName = menuName;
            EnMenuName = enMenuName;
            IsHidden = isHidden;
            BannerImg = bannerImg;
            WebsiteKeywords = websiteKeywords;
            WebsiteDescription = websiteDescription;
            Model = model;
            ListTemplateFile = listTemplateFile;
            ContentTemplateFile = contentTemplateFile;
            WebsiteCustomForms = websiteCustomForms;
        }

        public void ChangeOrder(int order)
        {
            this.Order = order;
        }
    }
}