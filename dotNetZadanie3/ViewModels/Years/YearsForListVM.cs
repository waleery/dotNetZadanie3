using System.ComponentModel.DataAnnotations;

namespace dotNetZadanie3.ViewModels.Years
{
	public class YearsForListVM
	{
		public int? Id { get; set; }

		[Display(Name = "Imie i nazwisko")]
		[Required(ErrorMessage = "Pole '{0}' jest wymagane!"),
		StringLength(100, ErrorMessage = "Pole {0} musi być krótsze niż {2} liter!")]
		public string FullName { get; set; }

		[Display(Name = "Rok urodzenia")]
		[Required(ErrorMessage = "Pole '{0}' jest wymagane!"), 
		Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}")]
		public int? Year { get; set; }


		[Display(Name = "Wynik zapytania")]
		public String? wynik { get; set; }
	}
}
