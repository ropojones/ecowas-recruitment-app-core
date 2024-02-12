using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;

namespace EcoRecruit.EntityFrameworkCore.Seed.Host
{
    public class DefaultLanguagesCreator
    {
        public static List<ApplicationLanguage> InitialLanguages => GetInitialLanguages();

        private readonly EcoRecruitDbContext _context;

        private static List<ApplicationLanguage> GetInitialLanguages()
        {
            var tenantId = EcoRecruitConsts.MultiTenancyEnabled ? null : (int?)MultiTenancyConsts.DefaultTenantId;
            return new List<ApplicationLanguage>
            {
                new ApplicationLanguage(tenantId, "en", "English", "famfamfam-flags us",false),
                new ApplicationLanguage(tenantId, "ar", "العربية", "famfamfam-flags sa",true),
                new ApplicationLanguage(tenantId, "de", "German", "famfamfam-flags de",true),
                new ApplicationLanguage(tenantId, "it", "Italiano", "famfamfam-flags it", true),
                new ApplicationLanguage(tenantId, "fa", "فارسی", "famfamfam-flags ir",true),
                new ApplicationLanguage(tenantId, "fr", "Français", "famfamfam-flags fr",false),
                new ApplicationLanguage(tenantId, "pt", "Português", "famfamfam-flags pt",false),
                new ApplicationLanguage(tenantId, "tr", "Türkçe", "famfamfam-flags tr", true),
                new ApplicationLanguage(tenantId, "ru", "Русский", "famfamfam-flags ru",true),
                new ApplicationLanguage(tenantId, "zh-Hans", "简体中文", "famfamfam-flags cn", true),
                new ApplicationLanguage(tenantId, "es-MX", "Español México", "famfamfam-flags mx", true),
                new ApplicationLanguage(tenantId, "nl", "Nederlands", "famfamfam-flags nl",true),
                new ApplicationLanguage(tenantId, "ja", "日本語", "famfamfam-flags jp", true)
            };
        }

        public DefaultLanguagesCreator(EcoRecruitDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.IgnoreQueryFilters().Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Languages.Add(language);
            _context.SaveChanges();
        }
    }
}
