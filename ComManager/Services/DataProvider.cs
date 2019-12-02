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

        public List<Computer> FetchComputers(int? roomFilter = null, string nameFilter = null, SortOrder nameSortOrder = SortOrder.None)
        {
            IQueryable<Computer> computers = _db.Computers.Include(c => c.Room);

            if (roomFilter != null)
            {
                computers = computers.Where(c => c.RoomId == roomFilter);
            }

            if (!String.IsNullOrEmpty(nameFilter))
            {
                computers = computers.Where(c => c.Name.Contains(nameFilter));
            }

            switch (nameSortOrder)
            {
                case SortOrder.Ascending :
                    computers = computers.OrderBy(c => c.Name);
                    break;
                case SortOrder.Descending:
                    computers = computers.OrderByDescending(c => c.Name);
                    break;
            }
            return computers.AsNoTracking().ToList();
        }

        public List<Room> FetchRooms(SortOrder nameSortOrder = SortOrder.None)
        {
            IQueryable<Room> rooms = _db.Rooms;

            switch (nameSortOrder)
            {
                case SortOrder.Ascending:
                    rooms = rooms.OrderBy(c => c.Name);
                    break;
                case SortOrder.Descending:
                    rooms = rooms.OrderByDescending(c => c.Name);
                    break;
            }

            return rooms.AsNoTracking().ToList();
        }
    }
}
