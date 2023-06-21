using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using Weather;
using WebApp1.Service;

namespace WebApp1.Pages;

public class ListConfig : PageModel
{
    public IConfiguration Config { get; set; }

    public ListConfig(IConfiguration config)
    {
        Config = config;
    }

    public void OnGet()
    {

    }
}
