using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Models.Admin.Request
{
    public class ProductCreateRequest
    {
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
    }
}