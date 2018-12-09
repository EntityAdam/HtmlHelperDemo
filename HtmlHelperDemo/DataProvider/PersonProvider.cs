using HtmlHelperDemo.Models;
using System.Collections.Generic;

namespace HtmlHelperDemo.DataProvider
{
    public class PersonProvider : IPersonProvider
    {
        public List<Person> Get() => new List<Person>()
        {
            new Person()
            {
                Id = 0,
                Name = "Adam Vincent",
                IsDeveloper = true,
                Address = new UsAddress()
                {
                    Address1 = "100 N. Duke St",
                    City = "Durham",
                    State = "NC",
                    PostalCode = new UsPostalCode() { Zip = "27704" }
                }
            },
            new Person()
            {
                Id = 1,
                Name = "Thomas Edison",
                IsDeveloper = false,
                Address = new UsAddress()
                {
                    Address1 = "1 River Rd",
                    CompanyName = "General Electric",
                    City = "Schenectady",
                    State = "NY",
                    PostalCode = new UsPostalCode() { Zip = "12345" }
                }
            },
        };
    }
}
