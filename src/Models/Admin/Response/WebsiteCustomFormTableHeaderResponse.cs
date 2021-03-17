using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class WebsiteCustomFormTableHeaderResponse : AggregateModel
    {
        public string Name { get; set; }
        public CustomParamTypes Type { get; set; }
    }
}