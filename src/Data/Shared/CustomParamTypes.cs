using System.ComponentModel;

namespace www.veinid365.cn.Data.Shared
{
    public enum CustomParamTypes : byte
    {
        [Description("单行文本")]
        Text = 0,
        [Description("多行文本")]
        TextArea,
        [Description("上传图片")]
        Image
    }
}