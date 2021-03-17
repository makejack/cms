using System;
using System.IO;
using Fluid;
using Fluid.Ast;
using Microsoft.AspNetCore.Hosting;
using www.veinid365.cn.Utils;

namespace www.veinid365.cn.Fluid
{
    public class RenderTagRegistering : IFluidRegisitering
    {
        private readonly IWebHostEnvironment _env;

        public RenderTagRegistering(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void Register(FluidParser parser)
        {
            parser.RegisterIdentifierTag("render", async (value, writer, encoder, context) =>
           {
               var source = Path.Combine(_env.WebRootPath, CommonConstant.UploadFolder, CommonConstant.UploadTemplateFolder, value + ".html");
               if (File.Exists(source))
               {
                   var htmlContent = File.ReadAllText(source);
                   if (parser.TryParse(htmlContent, out var template, out var error))
                   {
                       //    var templateContext = new TemplateContext();
                       var html = await template.RenderAsync(context);
                       await writer.WriteAsync(html);
                   }
                   else
                   {
                       await writer.WriteAsync(error);
                   }
               }
               return Completion.Normal;
           });
        }
    }
}