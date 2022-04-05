using dotNetZadanie3.Data;
using dotNetZadanie3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotNetZadanie3.Pages
{
    public class LastSearchedModel : PageModel
    {
        private readonly YearsContext _context;
        public IList<Years> YearsContext { get; set; }

        public LastSearchedModel(YearsContext context)
        {
            _context = context;
        }

        public void OnGet()
        {   
            //wyswietlanie ostatnich 20 wynikow z bazy
            YearsContext = _context.Years.OrderByDescending(x => x.date).Take(20).ToList();
        }
    }
}
