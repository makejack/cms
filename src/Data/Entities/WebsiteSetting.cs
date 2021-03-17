using System.Net.Cache;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using www.veinid365.cn.Models.Admin.Request;

namespace www.veinid365.cn.Data.Entities
{
    /// <summary>
    /// 网站设置
    /// </summary>
    public class WebsiteSetting : Aggregate
    {
        public WebsiteSetting()
        {
        }

        /// <summary>
        /// 网站名称
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(32)]
        public string WebsiteName { get; set; }
        /// <summary>
        /// 网站Logo
        /// </summary>
        /// <value></value>
        [MaxLength(512)]
        public string WebsiteLogo { get; set; }
        /// <summary>
        /// 地址栏图标
        /// </summary>
        /// <value></value>
        [MaxLength(512)]
        public string WebsiteAddressIcon { get; set; }
        /// <summary>
        /// 网站标题
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(256)]
        public string WebsiteTitle { get; set; }
        /// <summary>
        /// 网站地址
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(512)]
        public string WebsiteUrl { get; set; }
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
        /// 版权信息
        /// </summary>
        /// <value></value>
        [MaxLength(512)]
        public string Copyright { get; set; }
        /// <summary>
        /// 备案号
        /// </summary>
        /// <value></value>
        [MaxLength(512)]
        public string CaseNumber { get; set; }

        public virtual List<WebsiteCustomParam> WebsiteCustomParams { get; set; }



        public void Edit(WebsiteSettingSaveRequest request, List<WebsiteCustomParam> websiteCustomParams)
        {
            this.Id = request.Id;
            this.WebsiteName = request.WebsiteName;
            this.WebsiteLogo = request.WebsiteLogo;
            this.WebsiteAddressIcon = request.WebsiteAddressIcon;
            this.WebsiteTitle = request.WebsiteTitle;
            this.WebsiteUrl = request.WebsiteUrl;
            this.WebsiteKeywords = request.WebsiteKeywords;
            this.WebsiteDescription = request.WebsiteDescription;
            this.Copyright = request.Copyright;
            this.CaseNumber = request.CaseNumber;
            this.WebsiteCustomParams = websiteCustomParams;
        }

    }
}