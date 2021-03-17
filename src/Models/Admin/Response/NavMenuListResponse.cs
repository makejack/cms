using System.Collections.Generic;
using www.veinid365.cn.Data.Shared;

namespace www.veinid365.cn.Models.Admin.Response
{
    public class NavMenuListResponse : AggregateModel
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <value></value>
        public int Order { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        /// <value></value>
        public string MenuName { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        /// <value></value>
        public bool IsHidden { get; set; }
        /// <summary>
        /// 导航模型
        /// </summary>
        /// <value></value>
        public byte Model { get; set; }
        /// <summary>
        /// 导航模型
        /// </summary>
        /// <value></value>
        public string ModelDescription { get; set; }

        public List<NavMenuListResponse> Children { get; set; }
    }
}