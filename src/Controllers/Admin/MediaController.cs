using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using www.veinid365.cn.Models.Admin;
using www.veinid365.cn.Models.Admin.Response;
using www.veinid365.cn.Utils;
using src.Models.Admin.Request;

namespace www.veinid365.cn.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("api/admin/media")]
    public class MediaController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public MediaController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [AllowAnonymous]
        [HttpPost("upload/image")]
        public async Task<Result> UploadImage(IFormFile file)
        {
            var len = file.Length;
            if (len > 1024 * 1024 * 10) // 只能上传小于10M的文件
                return Result.Fail(ResultCodes.RequestParamError, "上传的图片不允许超过10M");
            var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString("N");
            var filePath = Path.Combine(CommonConstant.UploadFolder, CommonConstant.UploadImageFolder, DateTime.Now.ToString("yyyyMMdd"), fileName + extension);
            var physicalPath = Path.Combine(_env.WebRootPath, filePath);
            FileHelper.CreateFolder(physicalPath);

            using (var ms = new FileStream(physicalPath, FileMode.CreateNew, FileAccess.Write))
            {
                await file.CopyToAsync(ms);
            }

            var url = new StringBuilder().Append(Request.Scheme).Append("://").Append(Request.Host).ToString();
            // url + "/" + filePath.Replace(@"\", "/")
            return Result.Ok(new { Host = url + "/", Url = filePath.Replace(@"\", "/") });
        }


        [HttpGet("templatefiles")]
        public Result GetTemplateFiles()
        {
            var fileNames = new List<string>();
            var rootPath = _env.WebRootPath;
            var physicalFolder = Path.Combine(rootPath, CommonConstant.UploadFolder, CommonConstant.UploadTemplateFolder);
            if (Directory.Exists(physicalFolder))
            {
                var files = Directory.GetFiles(physicalFolder);
                foreach (var item in files)
                {
                    fileNames.Add(Path.GetFileName(item));
                }
            }

            return Result.Ok(fileNames);
        }


        [HttpGet("getfiles")]
        public Result GetFiles(string folder, string root)
        {
            var files = new List<FileResponse>();
            var relativelyPath = string.Empty;
            var physicalFolder = string.Empty;
            if (!string.IsNullOrEmpty(folder))
            {
                relativelyPath = folder;
                physicalFolder = Path.Combine(_env.WebRootPath, folder);
            }
            else if (!string.IsNullOrEmpty(root))
            {
                relativelyPath = root;
                physicalFolder = Path.Combine(_env.WebRootPath, root);
            }
            else
            {
                relativelyPath = "";
                physicalFolder = Path.Combine(_env.WebRootPath);
            }
            var direInfo = new DirectoryInfo(physicalFolder);
            if (direInfo.Exists)
            {
                if (!string.IsNullOrEmpty(folder))
                {
                    var length = folder.LastIndexOfAny(new char[] { '/', '\\' });
                    if (length > 0)
                    {
                        var prevFolder = folder.Substring(0, length);
                        files.Add(new FileResponse("上级目录", prevFolder));
                    }
                    else
                    {
                        files.Add(new FileResponse("上级目录", string.Empty));
                    }
                }
                foreach (var item in direInfo.GetDirectories())
                {
                    files.Add(new FileResponse(item.Name, Path.Combine(relativelyPath, item.Name)));
                }

                foreach (var item in direInfo.GetFiles())
                {
                    files.Add(new FileResponse(item.Name, Path.Combine(relativelyPath, item.Name), item.Length));
                }
            }
            return Result.Ok(files);
        }

        [HttpGet("file/content")]
        public async Task<Result> GetFileContent(string path)
        {
            var text = string.Empty;
            var physicalPath = Path.Combine(_env.WebRootPath, path);
            if (System.IO.File.Exists(physicalPath))
            {
                text = await System.IO.File.ReadAllTextAsync(physicalPath, Encoding.UTF8);
            }
            return Result.Ok(text);
        }

        [HttpPost("file/content")]
        public async Task<Result> ChangeFileContent([FromBody] MediaChangeFileContentRequest request)
        {
            var physicalPath = Path.Combine(_env.WebRootPath, request.Path, request.File);
            FileHelper.CreateFolder(physicalPath);
            await System.IO.File.WriteAllTextAsync(physicalPath, request.Content);
            return Result.Ok();
        }

        [HttpPost("folder/create")]
        public Result CreateFolder([FromBody] MediaCreateFolderRequest request)
        {
            var physicalPath = Path.Combine(_env.WebRootPath, request.Path);
            if (!Directory.Exists(physicalPath))
            {
                return Result.Fail(ResultCodes.RequestParamError, "目录不存在");
            }

            physicalPath = Path.Combine(physicalPath, request.Name);
            if (!Directory.Exists(physicalPath))
            {
                Directory.CreateDirectory(physicalPath);
            }
            return Result.Ok();
        }


        [HttpPost("upload")]
        public async Task<Result> Upload(IFormFile file, [FromForm] string path)
        {
            if (path == null)
            {
                path = "";
            }
            var fileName = Path.GetFileName(file.FileName);
            var physicalFolder = Path.Combine(path, fileName);
            var physicalPath = Path.Combine(_env.WebRootPath, physicalFolder);
            FileHelper.CreateFolder(physicalPath);

            if (System.IO.File.Exists(physicalPath))
            {
                System.IO.File.Delete(physicalPath);
            }

            using (var ms = new FileStream(physicalPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(ms);
            }

            var url = new StringBuilder().Append(Request.Scheme).Append("://").Append(Request.Host).ToString();
            // url + "/" + filePath.Replace(@"\", "/")
            return Result.Ok(fileName);
        }

        [HttpPost("upload/file")]
        public async Task<Result> UploadFile(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var fileSize = file.Length;
            var physicalFolder = Path.Combine(CommonConstant.UploadFolder, CommonConstant.UploadFileFolder, DateTime.Now.ToString("yyyyMMdd"), fileName);
            var physicalPath = Path.Combine(_env.WebRootPath, physicalFolder);
            FileHelper.CreateFolder(physicalPath);

            if (System.IO.File.Exists(physicalPath))
            {
                System.IO.File.Delete(physicalPath);
            }

            using (var ms = new FileStream(physicalPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(ms);
            }

            return Result.Ok(new FileResponse(fileName, physicalFolder, fileSize));
        }
    }
}