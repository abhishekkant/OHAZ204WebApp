using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IndexModel(IConfiguration config, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {
            ViewData["name"] = _config["Name"];
        }
    }
}
