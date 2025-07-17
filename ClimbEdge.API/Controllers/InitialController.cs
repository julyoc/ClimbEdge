using Asp.Versioning;
using ClimbEdge.Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [Route("api/")]
    public class InitialController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> Base() => Ok("Welcome to ClimbEdge API!");

        [HttpGet("info")]
        public ActionResult<Dictionary<string, Object>> Info()
        {
            return Ok(new Dictionary<string, Object>
            {
                { "DefaultVersion", Constants.DefaultApiVersion },
                { "AllowedVersions", Constants.AllowedApiVersions },
                { "CurrentVersion", HttpContext.GetRequestedApiVersion()?.ToString() ?? "Unknown" },
                { "ApiName", Constants.ApiName },
                { "ApiDescription", Constants.ApiDescription },
                { "DefaultDateFormat", Constants.DefaultDateFormat },
                { "DefaultDateTimeFormat", Constants.DefaultDateTimeFormat },
                { "DefaultTimeZone", Constants.DefaultTimeZone },
                { "DefaultTimeFormat", Constants.DefaultTimeFormat },
                { "DefaultDateTimeFormatWithZone", Constants.DefaultDateTimeFormatWithZone },
                { "DefaultDateTimeOffsetFormat", Constants.DefaultDateTimeOffsetFormat },
                { "CachingExpiration", Constants.CachingExpiration },
                { "MaxPageSize", Constants.MaxPageSize },
                { "DefaultPageSize", Constants.DefaultPageSize },
                { "RecentlyDaysThreshold", Constants.RecentlyDaysThreshold },
                { "DefaultCurrency", Constants.DefaultCurrency },
                { "DefaultLanguage", Constants.DefaultLanguage },
                { "DefaultCountry", Constants.DefaultCountry }
            });
        }
    }
}
