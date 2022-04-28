using dotNetZadanie3.ViewModels.Years;

namespace dotNetZadanie3.Interfaces
{
	public interface IYearsService
	{
		void AddEntry(YearsForListVM entry);

		ListYearsForListVM GetAllEntries();

		ListYearsForListVM GetEntriesFromToday();
	}
}
