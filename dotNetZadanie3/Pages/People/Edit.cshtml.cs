﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotNetZadanie3.Data;
using dotNetZadanie3.Models;

namespace dotNetZadanie3.Pages.People
{
    public class EditModel : PageModel
    {
        private readonly dotNetZadanie3.Data.YearsContext _context;

        public EditModel(dotNetZadanie3.Data.YearsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Years Years { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Years = await _context.Years.FirstOrDefaultAsync(m => m.Id == id);

            if (Years == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Years).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearsExists(Years.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool YearsExists(int id)
        {
            return _context.Years.Any(e => e.Id == id);
        }
    }
}
