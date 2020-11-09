using Microsoft.AspNetCore.Mvc;
using Tlu.CurriculumManager.Curriculums;
using Volo.Abp.AspNetCore.Mvc;
using RazorLight;
using System.IO;

namespace Tlu.CurriculumManager.Controllers
{
    [Route("api/controller/curriculums")]
    public class CurriculumController : AbpController
    {
        private readonly ICurriculumAppService _curriculumAppService;

        public CurriculumController(ICurriculumAppService curriculumAppService)
        {
            _curriculumAppService = curriculumAppService;
        }

        //[HttpGet]
        //[Route("exportPDF/{id}")]
        //public async IActionResult ExportPDFAsync(int id)
        //{
        //    var currentFolder = Directory.GetCurrentDirectory();
        //    var exports = await _curriculumAppService.ExportPDF(id);
        //    var engine = new RazorLightEngineBuilder()
        //        .UseFileSystemProject($"{currentFolder}\\Templates")
        //        .UseMemoryCachingProvider()
        //        .Build();
        //    var model = new { ExportPDFs = exports };
        //    string result = await engine.CompileRenderAsync("ExportCurriculumDetailPDF.cshtml", model);
        //}
    }
}
