using System;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class ProductListResponse : AggregateModel
    {
        public string Title { get; set; }
        public int Pageviews { get; set; }
        public bool IsPublished { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}