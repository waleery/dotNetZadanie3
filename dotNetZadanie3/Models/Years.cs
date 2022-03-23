using System;
using System.ComponentModel.DataAnnotations;
namespace dotNetZadanie3.Models
{
    public class Years
    {
        [Display(Name = "Imie")]
        [Required(ErrorMessage = "Pole '{0}' jest wymagane!"), StringLength(10, ErrorMessage = "Pole {0} musi być krótsze niż {2} liter!")]
        public string? Name { get; set; }

        [Display(Name = "Rok urodzenia")]
        [Required(ErrorMessage = "Pole '{0}' jest wymagane!"), Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}")]
        public int? Year { get; set; }

        public string YearCheck(int? number)
        {
            if(number % 4 == 0)
            {
                if(number % 100 == 0)
                {
                    if(number % 400 == 0)
                    {
                        return "To był rok przestepny.";
                    }
                    else
                    {
                        return "To nie był rok przestepny.";
                    }
                }
                else
                {
                    return "To był rok przestepny.";
                }
            }
            else
            {
                return "To nie był rok przestepny.";
            }
        }
    }
}

