using dotNetZadanie3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using dotNetZadanie3.Data;
using dotNetZadanie3.Interfaces;
using dotNetZadanie3.ViewModels.Years;

namespace dotNetZadanie3.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly IYearsService _yearsService;

    [BindProperty]
    public YearsForListVM Year { get; set; }

    public ListYearsForListVM Entries { get; set; }


    public string[] data;


    public IndexModel(ILogger<IndexModel> logger, IYearsService yearsService)
    {
        _logger = logger;
        _yearsService = yearsService;
    }

    public void OnGet()
    {
        Entries = _yearsService.GetEntriesFromToday();
    }

    public IActionResult OnPost()
    {
        var errors = ModelState.Values.SelectMany(v => v.Errors);

        if (ModelState.IsValid)
        {
            _yearsService.AddEntry(Year);
            return RedirectToPage("./Index");
           
        }
        else
        {
            return Page();




            /*data = new string[4];
            data[0] = Year.Name;
            data[1] = Year.Surname;
            data[2] = Year.Year.ToString();
            data[3] = Year.YearCheck(Year.Year);

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
            Result = data[0] +" "+ data[1] + " " + Year.NameCheck(Year.Name) + " się  w " + data[2] + ". " + data[3];
*/

            //Year.wynik = Result;



        }
    }
}

