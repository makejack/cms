namespace www.veinid365.cn.Models.Admin.Request
{
    public class NewsCreateRequest
    {
        public string ImageUrl { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        /// <value></value>
        public string Content { get; set; }
        public bool IsPublished { get; set; }
    }
}