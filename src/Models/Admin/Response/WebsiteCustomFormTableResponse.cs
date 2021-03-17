using System.Collections.Generic;
namespace www.veinid365.cn.Models.Admin.Response
{
    public class WebsiteCustomFormTableResponse
    {
        public WebsiteCustomFormTableResponse()
        {
        }

        public WebsiteCustomFormTableResponse(List<WebsiteCustomFormTableHeaderResponse> headers,
                                                  PaginationResponse table)
        {
            Headers = headers;
            Table = table;
        }

        public List<WebsiteCustomFormTableHeaderResponse> Headers { get; set; }

        public PaginationResponse Table { get; set; }
    }
}