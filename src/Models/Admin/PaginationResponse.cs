namespace www.veinid365.cn.Models.Admin
{
    public class PaginationResponse
    {
        public PaginationResponse()
        {
        }

        public PaginationResponse(int totalRows, object result)
        {
            TotalRows = totalRows;
            Result = result;
        }

        public int TotalRows { get; set; }

        public object Result { get; set; }
    }
}