using dotNetZadanie3.Data;
using dotNetZadanie3.Interfaces;
using dotNetZadanie3.Models;

namespace dotNetZadanie3.Repositories
{
	public class YearsRepository : IYearsRepository
	{
		private readonly YearsContext _context;

		public YearsRepository(YearsContext context)
		{
			_context = context;
		}
		public void AddEntry(Years entry)
		{
			IList<Years> years = _context.Years.ToList();
			_context.Years.Add(entry);
			_context.SaveChanges();
		}

		public IQueryable<Years> GetAllEntries()
		{
			return _context.Years;
		}

		public IQueryable<Years> GetEntriesFromToday()
		{
			return _context.Years.Where(x => x.date == DateTime.Today);
		}
	}
}
