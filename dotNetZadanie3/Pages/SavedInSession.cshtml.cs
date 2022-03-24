using dotNetZadanie3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;



namespace dotNetZadanie3.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public Years Year { get; set; }
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");

            if (Data != null)
            {
                Year = JsonConvert.DeserializeObject<Years>(Data);
            }
        }
    }
}
