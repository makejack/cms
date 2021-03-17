using System.Collections.Generic;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class WebsiteSettingResponse : AggregateModel
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        /// <value></value>
        public string WebsiteName { get; set; }
        /// <summary>
        /// 网站Logo
        /// </summary>
        /// <value></value>
        public string WebsiteLogo { get; set; }
        /// <summary>
        /// 地址栏图标
        /// </summary>
        /// <value></value>
        public string WebsiteAddressIcon { get; set; }
        /// <summary>
        /// 网站标题
        /// </summary>
        /// <value></value>
        public string WebsiteTitle { get; set; }
        /// <summary>
        /// 网站地址
        /// </summary>
        /// <value></value>
        public string WebsiteUrl { get; set; }
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
        /// 版权信息
        /// </summary>
        /// <value></value>
        public string Copyright { get; set; }
        /// <summary>
        /// 备案号
        /// </summary>
        /// <value></value>
        public string CaseNumber { get; set; }

        public List<WebsiteSettingCustomParamResponse> WebsiteCustomParams { get; set; }
    }
}