using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class WebsiteCustomFormListResponse : AggregateModel
    {
        public string Name { get; set; }
        public CustomParamTypes Type { get; set; }
        public string TypeDescription { get; set; }
        public bool IsRequired { get; set; }
        public bool IsShowList { get; set; }
    }
}