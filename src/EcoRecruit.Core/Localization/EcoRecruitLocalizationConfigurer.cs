﻿using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace EcoRecruit.Localization
{
    public static class EcoRecruitLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(EcoRecruitConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(EcoRecruitLocalizationConfigurer).GetAssembly(),
                        "EcoRecruit.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
