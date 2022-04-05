#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dotNetZadanie3.Data;
using dotNetZadanie3.Models;

namespace dotNetZadanie3.Pages.People
{
    public class CreateModel : PageModel
    {
        private readonly dotNetZadanie3.Data.YearsContext _context;

        public CreateModel(dotNetZadanie3.Data.YearsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Years Years { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Years.Add(Years);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
