using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NKS.Movies.API.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Contracts;

    
    [ApiController]
    [Route("[controller]")]
    public class InfoController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            var assembly = typeof(Startup).Assembly;

            var creationDate = System.IO.File.GetCreationTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {creationDate}");
        }
    }
}
