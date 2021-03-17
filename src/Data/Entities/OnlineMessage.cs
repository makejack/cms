using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Data.Entities
{
    /// <summary>
    /// 在线留言
    /// </summary>
    public class OnlineMessage : Aggregate
    {
        public OnlineMessage()
        {
        }

        public OnlineMessage(string userName, string tel, string email, string message)
        {
            this.UserName = userName;
            this.Tel = tel;
            this.Email = email;
            this.Message = message;
        }

        [Required]
        [MaxLength(512)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(512)]
        public string Tel { get; set; }
        [Required]
        [MaxLength(512)]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}