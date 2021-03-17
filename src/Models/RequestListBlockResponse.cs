namespace www.veinid365.cn.Models
{
    public class RequestListBlockResponse
    {
        public RequestListBlockResponse()
        {
        }

        public RequestListBlockResponse(int id, string title, string enTitle, object data)
        {
            Id = id;
            Title = title;
            EnTitle = enTitle;
            Data = data;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string EnTitle { get; set; }

        public object Data { get; set; }
    }
}