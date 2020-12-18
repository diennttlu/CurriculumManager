using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tlu.CurriculumManager.Documents;

namespace Tlu.CurriculumManager.Web.Pages.Outlines
{
    public class SelectDocumentModalModel : CurriculumManagerPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public SelectDocumentModalModel()
        {

        }
        public void OnGet()
        {

        }
    }
}
