using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BozonStore.Controllers
{
    public class CommonController : Controller
    {
        IWebHostEnvironment env;

        public CommonController(IWebHostEnvironment env)
        {
            this.env = env;
            
        }
        public IActionResult GetImage(string path)
        {
            var imageDir = env.ContentRootPath.Replace("\\","/");
            var fullPath = imageDir + path;
            return PhysicalFile(fullPath, "image/*");
        }
    }
}
