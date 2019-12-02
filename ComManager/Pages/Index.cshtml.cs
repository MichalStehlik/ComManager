using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComManager.Models;
using ComManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataProvider _dp;

        public List<Computer> Computers { get; set; }
        public SelectList RoomList { get; set; }
        public string NameSort { get; set; }
        public int? CurrentRoomFilter { get; set; }
        public string CurrentNameFilter { get; set; }

        public IndexModel(DataProvider dp)
        {
            _dp = dp;
        }

        public void OnGet(int? roomFilter, string nameFilter, string order = "name")
        {
            RoomList = new SelectList(_dp.FetchRooms(SortOrder.Ascending), nameof(Room.Id), nameof(Room.Name));

            CurrentNameFilter = nameFilter;
            CurrentRoomFilter = roomFilter;

            NameSort = order == "name" ? "name_desc" : "name";
            SortOrder ns;
            switch (order)
            {
                case "name_desc":
                    ns = SortOrder.Descending;
                    break;
                default:
                    ns = SortOrder.Ascending;
                    break;
            }
            Computers = _dp.FetchComputers(roomFilter, nameFilter, ns);
        }
    }
}
