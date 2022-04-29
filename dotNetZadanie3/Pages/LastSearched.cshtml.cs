using dotNetZadanie3.Data;
using dotNetZadanie3.Interfaces;
using dotNetZadanie3.Models;
using dotNetZadanie3.ViewModels.Years;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotNetZadanie3.Pages
{
    public class LastSearchedModel : PageModel
    {
        private readonly IYearsService _IYearsService;
        public ListYearsForListVM YearsContext { get; set; }

        public LastSearchedModel(IYearsService IYearsService)
        {
            _IYearsService = IYearsService;
        }

        public void OnGet()
        {
            //wyswietlanie ostatnich 20 wynikow z bazy
            YearsContext = _IYearsService.GetAllEntries();
        }
    }
}
