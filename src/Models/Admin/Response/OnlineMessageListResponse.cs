namespace www.veinid365.cn.Models.Admin.Response
{
    public class OnlineMessageListResponse : AggregateModel
    {
        public string UserName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}