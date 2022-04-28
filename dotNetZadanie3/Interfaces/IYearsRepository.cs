using dotNetZadanie3.Models;

namespace dotNetZadanie3.Interfaces
{
	public interface IYearsRepository
	{
		void AddEntry(Years entry);
		IQueryable<Years> GetAllEntries();
		IQueryable<Years> GetEntriesFromToday();
	}
}
