﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlHelperDemo.DataProvider;
using HtmlHelperDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmlHelperDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPersonProvider _personProvider;

        public IndexModel(IPersonProvider personProvider)
        {
            _personProvider = personProvider;
        }
        public IActionResult OnGet()
        {
            People = _personProvider.Get();
            return Page();
        }

        public List<Person> People { get; set; }
    }
}
