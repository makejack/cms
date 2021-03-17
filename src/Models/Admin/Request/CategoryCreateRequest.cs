using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Request
{
    public class CategoryCreateRequest
    {
        public string Title { get; set; }

        public CategoryTypes Type { get; set; }
    }
}