namespace www.veinid365.cn.Models.Admin
{
    public class PaginationRequest
    {
        private int _page;
        public int Page
        {
            get
            {
                if (_page == 0)
                    return 1;
                return _page;
            }
            set { _page = value; }
        }

        private int _limit;
        public int Limit
        {
            get
            {
                if (_limit == 0)
                    return 10;
                return _limit;
            }
            set { _limit = value; }
        }

    }
}