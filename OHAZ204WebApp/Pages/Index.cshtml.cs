using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OHAZ204WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;
        private TelemetryClient aiTelemetry;

        public IndexModel(TelemetryClient telemetry, IConfiguration config, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _config = config;
            aiTelemetry = telemetry;
        }

        public void OnGet()
        {
            aiTelemetry.TrackEvent("Request_HomePage");
            try
            {
                ViewData["name"] = _config["Name"];
                //throw new ApplicationException("Intentional Exception");
            }
            catch (Exception ex)
            {
                aiTelemetry.TrackException(ex);
            }
        }
    }
}
