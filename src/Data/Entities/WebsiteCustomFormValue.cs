namespace www.veinid365.cn.Data.Entities
{
    public class WebsiteCustomFormValue : Aggregate
    {
        public WebsiteCustomFormValue()
        {
        }

        public WebsiteCustomFormValue(int navMenuId, string value)
        {
            NavMenuId = navMenuId;
            Value = value;
        }

        public int NavMenuId { get; set; }
        public virtual NavMenu NavMenu { get; set; }

        public string Value { get; set; }
    }
}