using System.Collections.Generic;

namespace Bownty.Localisation
{
    public class LocalisationCache
    {
        static Dictionary<CacheKey, string> Cache = new Dictionary<CacheKey, string>();

        public void AddItem(string iso, string slug, string translation)
        {
            var key = new CacheKey(slug, iso);
            Cache.Add(key, translation);
        }

        public void AddItem(CacheKey key, string translation)
        {
            Cache.Add(key, translation);
        }

        public string GetTranslation(string iso, string slug)
        {
            var key = new CacheKey(slug, iso);
            return Cache[key];
        }
    }
}
