using System;
using System.Collections.Generic;
using System.Text;
using Tlu.CurriculumManager.Localization;
using Volo.Abp.Application.Services;

namespace Tlu.CurriculumManager
{
    /* Inherit your application services from this class.
     */
    public abstract class CurriculumManagerAppService : ApplicationService
    {
        protected CurriculumManagerAppService()
        {
            LocalizationResource = typeof(CurriculumManagerResource);
        }
    }
}
