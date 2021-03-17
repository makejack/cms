using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Data.Entities
{
    public class WarrantyActivation : Aggregate
    {
        public WarrantyActivation()
        {
        }

        public WarrantyActivation(string serialNumber, string userName, string agentName, string purchaseDate, string email, string tel, string imgUrl)
        {
            this.SerialNumber = serialNumber;
            this.UserName = userName;
            this.AgentName = agentName;
            this.PurchaseDate = purchaseDate;
            this.Email = email;
            this.Tel = tel;
            this.ImgUrl = imgUrl;
        }

        /// <summary>
        /// 序列号
        /// </summary>
        [Required]
        [MaxLength(512)]
        public string SerialNumber { get; set; }
        /// <summary>
        /// 用户称呼
        /// </summary>
        [Required]
        [MaxLength(512)]
        public string UserName { get; set; }
        /// <summary>
        /// 代理商名称
        /// </summary>
        [MaxLength(512)]
        public string AgentName { get; set; }
        /// <summary>
        /// 购买日期
        /// </summary>
        [MaxLength(32)]
        public string PurchaseDate { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string Tel { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        [Required]
        [MaxLength(512)]
        public string ImgUrl { get; set; }
    }
}