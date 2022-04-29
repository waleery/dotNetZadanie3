using dotNetZadanie3.Interfaces;
using dotNetZadanie3.Models;
using dotNetZadanie3.ViewModels.Years;

namespace dotNetZadanie3.Services
{
	public class YearsService : IYearsService
	{
		private readonly IYearsRepository _yearsRepository;

		public YearsService(IYearsRepository yearsRepository)
		{
			_yearsRepository = yearsRepository;
		}

		public void AddEntry(YearsForListVM entry)
		{
			string[] split = entry.FullName.Split(' ');
			Years years = new Years()
			{
				Name = split[0],
				Surname = (split.Length > 1 ? split[1] : ""),
				Year = entry.Year,
				date = DateTime.Today,
				wynik = entry.wynik
			};

		_yearsRepository.AddEntry(years);
		}

		public ListYearsForListVM GetAllEntries()
		{
			var YearsData = _yearsRepository.GetAllEntries();
			ListYearsForListVM result = new ListYearsForListVM();

			result.Years = new List<YearsForListVM>();
			foreach (var years in YearsData)
			{
				var yVM = new YearsForListVM()
				{
					Id = years.Id,
					FullName = years.Name + (years.Surname != "" ? " " + years.Surname : ""),
					Year = years.Year,
					wynik = years.YearCheck(years.Year)
				};
				result.Years.Add(yVM);
			}
			result.Count = result.Years.Count;
			return result;
		}

		public ListYearsForListVM GetEntriesFromToday()
		{
			var yearsData = _yearsRepository.GetEntriesFromToday();
			ListYearsForListVM result = new ListYearsForListVM();

			result.Years = new List<YearsForListVM>();
			foreach (var years in yearsData)
			{
				var yVM = new YearsForListVM()
				{
					Id = years.Id,
					FullName = years.Name + (years.Surname != "" ? " " + years.Surname : ""),
					Year = years.Year,
					wynik = years.YearCheck(years.Year)
				};
				result.Years.Add(yVM);
			}
			result.Count = result.Years.Count;
			return result;
		}
	}
}
