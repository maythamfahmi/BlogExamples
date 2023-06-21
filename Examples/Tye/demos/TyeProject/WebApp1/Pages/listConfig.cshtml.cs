using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace WebApp1.Pages
{
    public class listConfigModel : PageModel
    {
        public listConfigModel(IConfiguration configuration)
        {
            this.Config = configuration;
        }

        public IConfiguration Config
        {
            get;set;
        }

        public void OnGet()
        {
        }
    }
}
