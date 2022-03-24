using dotNetZadanie3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dotNetZadanie3.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public Years Year {get; set;}

    

    //public string Text { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        else
        {
            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Year));
            //HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Text));
            //return RedirectToPage("./SavedInSession");
            ViewData["Result"] = Year.Name + Year.NameCheck(Year.Name) + " się  w " + Year.Year +". " + Year.YearCheck(Year.Year);
            return Page();
        }
    }
}

