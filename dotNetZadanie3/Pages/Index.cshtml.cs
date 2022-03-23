using dotNetZadanie3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotNetZadanie3.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public Years Year {get; set;}

    

    public string Text { get; set; }

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
            ViewData["Result"] = Year.Name + " urodził się  w "+ Year.Year +". " + Year.YearCheck(Year.Year);
            return Page();
        }
    }
}

