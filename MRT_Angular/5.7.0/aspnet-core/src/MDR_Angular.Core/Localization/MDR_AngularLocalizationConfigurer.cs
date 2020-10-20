using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MDR_Angular.Localization
{
    public static class MDR_AngularLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MDR_AngularConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MDR_AngularLocalizationConfigurer).GetAssembly(),
                        "MDR_Angular.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
