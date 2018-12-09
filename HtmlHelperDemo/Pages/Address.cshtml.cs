using System.Collections.Generic;
using HtmlHelperDemo.DataProvider;
using HtmlHelperDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmlHelperDemo.Pages
{
    public class AddressModel : PageModel
    {
        private readonly IPersonProvider _personProvider;

        public AddressModel(IPersonProvider personProvider)
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