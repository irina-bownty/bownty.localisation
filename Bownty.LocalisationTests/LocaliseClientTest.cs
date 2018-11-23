using Bownty.Localisation;
using Bownty.Logger;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using System.Threading;
using Xunit;

namespace Bownty.LocalisationTests
{
    public class LocaliseClientTest
    {
        [Fact]
        public void TestRegex()
        {
            var result = Regex.Replace("If you'd rather not receive e-mails, %ssimply unsubscribe%s", @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);
        }


        [Fact]
        public void GetFileTest()
        {
            var config = new LocaliseConfig()
            {
                URL = "https://api.lokalise.co/api2/projects/{project_id}/",
                Token = "73992d38c71b9911d7d1c21c9a987b3a1afebf0e",
                ProjectId = "621654925bf685fd8cb822.13757911"
            };
            var options = Options.Create(config);

            var lc = new LocaliseClient(options, new BowntyLogger());
            // Define the cancellation token.
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            lc.Initialize(token).Wait();

            var localisedFromCache = lc.Cache.GetTranslation("dk", "%s Newsletter");
            var localised = lc.LocaliseStringFromFile("dk", "email", "%s Newsletter");
        }
    }
}
