using www.veinid365.cn.Data.Shared;
using www.veinid365.cn.Models.Admin;

namespace www.veinid365.cn.Models
{
    public class CategoryQueryRequest : PaginationRequest
    {
        public int? CategoryId { get; set; }
    }
}