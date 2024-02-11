using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EcoRecruit.Controllers
{
    public abstract class EcoRecruitControllerBase: AbpController
    {
        protected EcoRecruitControllerBase()
        {
            LocalizationSourceName = EcoRecruitConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
