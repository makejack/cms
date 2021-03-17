
using System.ComponentModel;

namespace www.veinid365.cn.Data.Shared
{
    /// <summary>
    /// 导航菜单模型
    /// </summary>
    public enum NavMenuModels : byte
    {
        /// <summary>
        /// 单页模型
        /// </summary>
        [Description("单面模型")]
        SinglePage = 0,
        /// <summary>
        /// 列表模型
        /// </summary>
        [Description("列表模型")]
        ListPage,
        /// <summary>
        /// 下载模型
        /// </summary>
        [Description("下载模型")]
        DownloadPage,
        /// <summary>
        /// 表单模型
        /// </summary>
        [Description("表单模型")]
        CustomForm,
    }
}