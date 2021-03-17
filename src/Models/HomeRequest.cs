namespace www.veinid365.cn.Models
{
    public class HomeRequest
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        /// <value></value>
        public int Mid { get; set; }
        /// <summary>
        /// 视图Id
        /// </summary>
        /// <value></value>
        public int Vid { get; set; }



        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 10;
    }
}