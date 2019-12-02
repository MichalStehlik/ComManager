using ComManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComManager.Services
{
    public class DataProvider
    {
        private ApplicationDbContext _db;

        public DataProvider(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Computer> FetchComputers(SortOrder nameSortOrder = SortOrder.None)
        {
            IQueryable<Computer> computers = _db.Computers;
            switch (nameSortOrder)
            {
                case SortOrder.Ascending :
                    computers.OrderBy(c => c.Name);
                    break;
                case SortOrder.Descending:
                    computers.OrderByDescending(c => c.Name);
                    break;
            }
            return computers.AsNoTracking().ToList();
        }
    }
}
