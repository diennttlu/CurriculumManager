using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using Volo.Abp.AspNetCore.Mvc;

namespace Tlu.CurriculumManager.Controllers
{
    [Route("api/controller/subjects")]
    public class SubjectController : AbpController
    {
        [HttpGet]
        [Route("downloadFile")]
        public IActionResult DownloadFile()
        {
            var filename = "subject.xlsx";
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/templates", filename);
            var provider = new FileExtensionContentTypeProvider();
            var memi = provider.Mappings[Path.GetExtension(path)];
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            return File(fileStream, memi, filename, true);
        }
    }
}
