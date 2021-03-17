namespace www.veinid365.cn.Models.Admin.Response
{
    public class ProductGetResponse : AggregateModel
    {
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
    }
}