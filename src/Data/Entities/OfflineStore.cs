using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Data.Entities
{
    /// <summary>
    /// 线下门店
    /// </summary>
    public class OfflineStore : Aggregate
    {
        public OfflineStore()
        {
        }

        public OfflineStore(string imageUrl, string storeName)
        {
            Edit(imageUrl, storeName);
        }

        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(512)]
        public string StoreName { get; set; }

        public void Edit(string imageUrl, string storeName)
        {
            this.ImageUrl = imageUrl;
            this.StoreName = storeName;
        }

    }
}