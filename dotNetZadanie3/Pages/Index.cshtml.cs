using dotNetZadanie3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dotNetZadanie3.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;


    public string[] data;

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
            data = new string[3];
            data[0] = Year.Name;
            data[1] = Year.Year.ToString();
            data[2] = Year.YearCheck(Year.Year);

            List<string[]> cache;

            var Data = HttpContext.Session.GetString("Data");

            if (Data != null)
            {
                cache = JsonConvert.DeserializeObject<List<string[]>>(Data);
            }
            else
            {
                cache = new List<string[]>();
            }

            cache.Add(data);
            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(cache));
            ViewData["Result"] = data[0] + Year.NameCheck(Year.Name) + " się  w " + data[1] + ". " + data[2];

            return Page();
            //HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Year));
            //return Page();

            //HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Text));
            //return RedirectToPage("./SavedInSession");
        }
    }
}

