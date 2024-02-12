using EcoRecruit.Debugging;

namespace EcoRecruit
{
    public class EcoRecruitConsts
    {
        public const string LocalizationSourceName = "EcoRecruit";

        public const string ConnectionStringName = "EcoRecruitConn";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "d97eb870271c46d584c14607b8061c06";
    }
}
