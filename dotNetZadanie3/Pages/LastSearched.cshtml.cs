using dotNetZadanie3.Data;
using dotNetZadanie3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotNetZadanie3.Pages
{
    [Authorize]
    public class LastSearchedModel : PageModel
    {
        private readonly YearsContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IList<Years> YearsContext { get; set; }

        public string obecnyUzytkownik { get; set; }

        public LastSearchedModel(YearsContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void OnGet()
        {   
            //wyswietlanie ostatnich 20 wynikow z bazy
            YearsContext = _context.Years.OrderByDescending(x => x.date).Take(20).ToList();
            
            obecnyUzytkownik = _userManager.GetUserId(User);
        }

        public IActionResult OnPostDeleteRecord(int id)
        {
            _context.Remove(_context.Years.Single(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToPage("./LastSearched");
        }

    }
}
