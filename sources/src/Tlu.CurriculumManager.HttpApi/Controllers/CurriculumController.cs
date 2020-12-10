using Microsoft.AspNetCore.Mvc;
using Tlu.CurriculumManager.Curriculums;
using Volo.Abp.AspNetCore.Mvc;
using RazorLight;
using System.IO;
using System.Threading.Tasks;
using IronPdf;

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

        [HttpGet]
        [Route("exportPDF/{id}")]
        public async Task<IActionResult> ExportPDFAsync(int id)
        {
            var currentFolder = Directory.GetCurrentDirectory();
            var exports = await _curriculumAppService.GetSubjectGroupsByCurriculumId(id);
            var curriculum = await _curriculumAppService.GetAsync(id);
            var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject($"{currentFolder}\\Templates")
                .UseMemoryCachingProvider()
                .Build();
            var model = new ExportPDFDto() 
            { 
                SubjectGroupReports = exports,
                Curriculum = curriculum
            };
            string html = await engine.CompileRenderAsync("ExportCurriculumDetailPDF.cshtml", model);
            var converter = new HtmlToPdf();
            var pdf = converter.RenderHtmlAsPdf(html);
            
            FileStreamResult fileStreamResult = new FileStreamResult(pdf.Stream, "application/pdf");
            fileStreamResult.FileDownloadName = $"{curriculum.Name} - {curriculum.SchoolYear.Name}.pdf";

            return fileStreamResult;
        }
    }
}
