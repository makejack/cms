namespace www.veinid365.cn.Models.Admin.Response
{
    public class SolutionDetailResponse : AggregateModel
    {
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
        /// <summary>
        /// 中文标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublished { get; set; }
    }
}