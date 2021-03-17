namespace www.veinid365.cn.Models.Admin.Response
{
    public class FileResponse
    {
        public FileResponse()
        {
        }

        public FileResponse(string fileName, string fileUrl)
        {
            FileName = fileName;
            FileUrl = fileUrl;
            IsFolder = true;
        }

        public FileResponse(string fileName, string fileUrl, long fileSize)
        {
            FileName = fileName;
            FileUrl = fileUrl.Replace(@"\", "/");
            FileSize = fileSize;
        }

        public string FileName { get; set; }

        public string FileUrl { get; set; }

        public long FileSize { get; set; }

        public bool IsFolder { get; set; }
    }
}