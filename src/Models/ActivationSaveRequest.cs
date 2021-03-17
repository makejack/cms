using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Models
{
    public class ActivationSaveRequest
    {
        [Required(ErrorMessage = "请输入序列号")]
        public string SerialNumber { get; set; }
        [Required(ErrorMessage = "请输入用户称呼")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "请输入代理商名称")]
        public string AgentName { get; set; }
        [Required(ErrorMessage = "请输入购买日期")]
        public string PurchaseDate { get; set; }
        [Required(ErrorMessage = "请输入邮箱")]
        [DataType(DataType.EmailAddress, ErrorMessage = "邮箱格式不正确")]
        public string Email { get; set; }
        [Required(ErrorMessage = "请输入手机号")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "手机号格式不正确")]
        public string Tel { get; set; }
        [Required(ErrorMessage = "请输入图片")]
        public string ImgUrl { get; set; }
    }
}