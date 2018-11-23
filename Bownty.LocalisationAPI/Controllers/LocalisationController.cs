using Bownty.Localisation;
using Bownty.LocalisationAPI.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace Bownty.LocalisationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalisationController : ControllerBase
    {
        public LocalisationController(LocaliseClient client)
        {
            _localiseClient = client;
        }

        private LocaliseClient _localiseClient;

        [HttpGet("{scope}/{slug}/{iso}")]
        public ActionResult<string> Get(string iso, string scope, string slug)
        {
            var localised = _localiseClient.Cache.GetTranslation(iso, slug);
            return new JsonResult(new { localised, slug }) { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("processlist")]
        public ActionResult<string> ProcessList(IEnumerable<LocalisationRequest> request)
        {
            var resultCollection = new List<LocalisationResponse>();
            foreach (var localisationRequest in request)
            {
                var localised = _localiseClient.Cache.GetTranslation(localisationRequest.ISO, localisationRequest.Slug);
                resultCollection.Add(new LocalisationResponse() { Localised = localised, Slug = localisationRequest.Slug });
            }
            return new JsonResult(resultCollection) { StatusCode = (int)HttpStatusCode.OK };
        }
    }
}