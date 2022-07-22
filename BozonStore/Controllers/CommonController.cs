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
        [HttpGet]
        public IActionResult GetProposalImage(string prodId,string imageName)
        {
            var imageDir = env.WebRootPath.Replace("\\","/")+"/Content/Proposal/";
            var fullPath = imageDir + prodId+"/"+ imageName;
            return PhysicalFile(fullPath, "image/*");
        }
    }
}
