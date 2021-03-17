namespace www.veinid365.cn.Models.Admin.Request
{
    public class DownloadFileRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        /// <value></value>
        public string FileName { get; set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        /// <value></value>
        public string FileUrl { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string Title { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        /// <value></value>
        public long FileSize { get; set; }
    }
}