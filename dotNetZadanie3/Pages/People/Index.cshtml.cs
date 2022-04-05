#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dotNetZadanie3.Data;
using dotNetZadanie3.Models;

namespace dotNetZadanie3.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly dotNetZadanie3.Data.YearsContext _context;

        public IndexModel(dotNetZadanie3.Data.YearsContext context)
        {
            _context = context;
        }

        public IList<Years> Years { get;set; }

        public async Task OnGetAsync()
        {
            Years = await _context.Years.ToListAsync();
        }
    }
}
