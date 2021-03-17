namespace src.Models.Admin.Request
{
    public class MediaChangeFileContentRequest
    {
        public string Path { get; set; }

        public string File { get; set; }

        public string Content { get; set; }
    }
}