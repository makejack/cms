using System.ComponentModel.DataAnnotations;
using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Data.Entities
{
    public class WebsiteCustomParam : Aggregate
    {
        public int WebsiteSettingId { get; set; }
        public virtual WebsiteSetting WebsiteSetting { get; set; }
        [Required]
        [MaxLength(512)]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }

        public CustomParamTypes Type { get; set; }
    }
}