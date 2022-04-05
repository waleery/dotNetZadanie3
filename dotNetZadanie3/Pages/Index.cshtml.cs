﻿using dotNetZadanie3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using dotNetZadanie3.Data;

namespace dotNetZadanie3.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly YearsContext _context;


    public string[] data;

    [BindProperty]
    public Years Year {get; set;}

    public string Result {get; set;}

    public IList<Years> Years { get; set; }

    public IndexModel(ILogger<IndexModel> logger, YearsContext context)
    {
        _logger = logger;
        _context = context;
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
            data = new string[4];
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
            Result = data[0] +" "+ data[1] + Year.NameCheck(Year.Name) + " się  w " + data[2] + ". " + data[3];

            
            Year.wynik = Result;
            Year.date = DateTime.Now;
            _context.Years.Add(Year);
            _context.SaveChanges();  

            return Page();


            //HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Year));
            //return Page();

            //HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Text));
            //return RedirectToPage("./SavedInSession");
        }
    }
}

