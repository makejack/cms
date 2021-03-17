using System.IO;

namespace www.veinid365.cn.Utils
{
    public class FileHelper
    {

        public static void CreateFolder(string fileFullPath)
        {
            DirectoryInfo dir = null;
            if (!System.IO.File.Exists(fileFullPath))
            {
                string[] pathes = fileFullPath.Split('\\');
                if (pathes.Length > 1)
                {
                    string path = pathes[0];
                    for (int i = 1; i < pathes.Length - 1; i++)
                    {
                        path += "\\" + pathes[i];
                        if (!Directory.Exists(path))
                        {
                            dir = Directory.CreateDirectory(path);
                        }
                    }
                }
            }
        }
    }
}