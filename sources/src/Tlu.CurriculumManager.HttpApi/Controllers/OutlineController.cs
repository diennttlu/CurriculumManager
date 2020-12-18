using IronPdf;
using Microsoft.AspNetCore.Mvc;
using RazorLight;
using System.IO;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Outlines;
using Volo.Abp.AspNetCore.Mvc;

namespace Tlu.CurriculumManager.Controllers
{
    [Route("api/controller/outlines")]
    public class OutlineController : AbpController
    {
        private readonly IOutlineAppService _outlineAppService;

        public OutlineController(IOutlineAppService outlineAppService)
        {
            _outlineAppService = outlineAppService;
        }

        [HttpGet]
        [Route("exportPDF/{id}")]
        public async Task<IActionResult> ExportPDFAsync(int id)
        {
            var currentFolder = Directory.GetCurrentDirectory();
            var export = await _outlineAppService.GetDetailById(id);
            var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject($"{currentFolder}\\Templates")
                .UseMemoryCachingProvider()
                .Build();
            var model = export;
            string html = await engine.CompileRenderAsync("ExportOutlineDetailPDF.cshtml", model);
            var converter = new HtmlToPdf();
            var pdf = converter.RenderHtmlAsPdf(html);

            FileStreamResult fileStreamResult = new FileStreamResult(pdf.Stream, "application/pdf");
            fileStreamResult.FileDownloadName = $"De Cuong {model.Subject.Name} - {model.SchoolYear.Name}.pdf";

            return fileStreamResult;
        }
    }
}
