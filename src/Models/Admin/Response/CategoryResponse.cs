using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class CategoryResponse : AggregateModel
    {
        public string Title { get; set; }

        public CategoryTypes Type { get; set; }
    }
}