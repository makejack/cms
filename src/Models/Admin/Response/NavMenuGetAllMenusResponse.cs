using System.Collections.Generic;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class NavMenuGetAllMenusResponse : AggregateModel
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        /// <value></value>
        public string MenuName { get; set; }

        public List<NavMenuGetAllMenusResponse> Children { get; set; }
    }
}