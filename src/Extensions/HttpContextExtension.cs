using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace www.veinid365.cn.Extensions
{
    public static class HttpContextExtension
    {
        public static int GetUserId(this HttpContext httpContext)
        {
            var strId = httpContext.User.Claims.FirstOrDefault(e => e.Type == "id").Value;
            return Convert.ToInt32(strId);
        }
    }
}