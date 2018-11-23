using System.Collections.Generic;

namespace Bownty.Localisation
{
    public class ISOCodes
    {
        public static Dictionary<string, string> Mapper = new Dictionary<string, string>
        {
            {"dk", "dan"},
            {"da", "dan"},
            {"be", "nl_be"},
            {"nl", "nld"},
            {"en", "eng"},
            {"fr", "fra"},
            {"de", "deu"},
            {"it", "ita"},
            {"pt", "por"},
            {"es", "spa"}
        };

        /// <summary>
        /// Mapping ISO codes to database ISO codes
        /// </summary>
        public static Dictionary<string, string> CustomMapper = new Dictionary<string, string>
        {
            {"dan","dk"},
            {"nl_be", "be" },
            {"nld", "nl"},
            {"eng", "en"},
            {"fra", "fr"},
            {"deu", "de"},
            {"ita", "it"},
            {"por", "pt"},
            {"spa", "es"},

            {"da","dk"},
            {"nl_BE", "be" },
            {"nl", "nl"},
            {"en", "en"},
            {"fr", "fr"},
            {"de", "de"},
            {"it", "it"},
            {"pt_PT", "pt"},
            {"es_ES", "es"}
        };
    }
}
