using System.ComponentModel.DataAnnotations;

namespace www.veinid365.cn.Data.Entities
{
    public class DownloadFile : Aggregate
    {
        public int PageContentId { get; set; }
        public virtual PageContent PageContent { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(512)]
        public string FileName { get; set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(512)]
        public string FileUrl { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(512)]
        public string Title { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        /// <value></value>
        public long FileSize { get; set; }
    }
}