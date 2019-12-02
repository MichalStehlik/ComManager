﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComManager.Models;
using ComManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ComManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataProvider _dp;

        public List<Computer> Computers { get; set; }
        public string NameSort { get; set; }

        public IndexModel(DataProvider dp)
        {
            _dp = dp;
        }

        public void OnGet(string order = "name")
        {
            NameSort = order == "name" ? "name_desc" : "name";
            SortOrder ns;
            switch (order)
            {
                case "name_desc":
                    ns = SortOrder.Ascending;
                    break;
                default:
                    ns = SortOrder.Descending;
                    break;
            }
            Computers = _dp.FetchComputers(ns);
        }
    }
}
